using System;
using System.Activities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Xml;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using PowerArgs;
using Xrm.PluginDeployer.Entities;
using Xrm.PluginDeployer.References.StepModel;
using Xrm.PluginDeployer.UnitOfWork;
using Xrm.PluginDeployer.Utility;


namespace Xrm.PluginDeployer
{
    public class PluginDeployer
    {
        private readonly ConsoleLogger logger;
        private readonly IOrganizationService sourceSystem;
        private readonly IOrganizationService destinationSystem;
        private readonly string solutionPreFix;
        private string SolutionName { get; set; }

        /// <summary>
        /// Plugin Assembly
        /// </summary>
        public Assembly AssemblyPlugin { get; private set; }

        /// <summary>
        /// XmlDocument containing the assembly documentation
        /// </summary>
        private XmlDocument CommentXml { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public PluginDeployer( IOrganizationService sourceSystem,
                               IOrganizationService destinationSystem,
                               string solutionPreFix,
                               ConsoleLogger logger )
        {
            this.sourceSystem = sourceSystem;
            this.destinationSystem = destinationSystem;
            this.logger = logger;
            this.solutionPreFix = solutionPreFix;
        }

        /// <summary>
        /// Load the assembly and generate a solutionName
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool LoadAssembly( string filePath )
        {
            if( !File.Exists( filePath ) )
            {
                logger.Log( $"Could not find the specified assembly at {filePath}" );
                return false;
            }

            GenerateSolutionName( filePath );

            logger.Log( "Assembly loaded" );

            var xmlPath = filePath.Replace( ".dll", ".xml" );
            if( !File.Exists( xmlPath ) )
            {
                logger.Log( $"Could not find the corresponding xml file at {xmlPath}" );
                return false;
            }

            CommentXml = new XmlDocument( );
            CommentXml.Load( xmlPath );

            return true;
        }

        private void GenerateSolutionName( string filePath )
        {
            AssemblyPlugin = Assembly.LoadFrom( filePath );
            SolutionName = solutionPreFix + AssemblyPlugin.GetName( ).Name.Replace( ".", "" ).Replace( "_", "" ).Replace( "-", "" );

            if( SolutionName.Length > 50 )
            {
                SolutionName = SolutionName.Substring( 0, 50 );
            }
        }

        /// <summary>
        /// Create or update the PluginAssembly depending on the given pluginAssemblyEntity
        /// </summary>
        /// <param name="pluginAssembly">PluginAssembly or null</param>
        /// <returns></returns>
        private PluginAssembly UploadPluginAssemblyToDestination( PluginAssembly pluginAssembly )
        {
            if( AssemblyPlugin == null )
            {
                throw new InvalidOperationException( "Load Assembly first" );
            }

            var dllContentBytes = File.ReadAllBytes( AssemblyPlugin.Location );
            var dllContent = Convert.ToBase64String( dllContentBytes );

            if( pluginAssembly == null )
            {
                return CreatePluginAssembly( destinationSystem, AssemblyPlugin, dllContent );
            }

            UpdatePluginAssembly( destinationSystem, pluginAssembly, dllContent );
            return pluginAssembly;

        }

        /// <summary>
        /// Create PluginType Entries in the destination system for all pluginTypes and workflows
        /// which are found in the assembly but are not registered in the destination system yet
        /// 
        /// Workflows are a special type of PluginType
        /// </summary>
        /// <param name="pluginAssembly">PluginAssembly from the destination system</param>
        private void CreateNewPluginTypesInDestination( Entity pluginAssembly )
        {
            var foundPlugins = SearchForPlugins( ).ToList( );
            var registeredPluginTypes = RetrievePluginTypes( destinationSystem, pluginAssembly.Id ).ToList( );

            // Create new pluginTypes
            foreach( var type in foundPlugins )
            {
                var pluginType = registeredPluginTypes.FirstOrDefault( registeredPluginType =>
                                                                           registeredPluginType.TypeName.Equals( type.FullName ) );
                if( pluginType != null )
                {
                    UpdatePluginType( destinationSystem, pluginType, type );
                }
                else
                {
                    CreatePluginType( destinationSystem, pluginAssembly.Id, type );
                }
            }

            // Create new workflows
            var foundWorkflows = SearchForWorkflows( ).ToList( );
            foreach( var type in foundWorkflows )
            {
                if( !registeredPluginTypes.Any( registeredPluginType =>
                                                    registeredPluginType.TypeName.Equals( type.FullName ) ) )
                {
                    CreatePluginType( destinationSystem, pluginAssembly.Id, type );
                }
            }
        }

        private void DeleteStepsByPluginType( Entity pluginType )
        {
            var dependentObjects = RetrieveSdkStepsByPluginType( destinationSystem, pluginType );
            DeleteDependentObjects( destinationSystem, dependentObjects );
        }

        private void DeleteDependentObjects( IOrganizationService service, IEnumerable< Dependency > dependentObjects )
        {
            foreach( var d in dependentObjects )
            {
                if( d.DependentComponentType.Value ==
                    ( int ) SolutionComponent.OptionSet.ComponentType.SdkMessageProcessingStep )
                {
                    if( d.DependentComponentObjectId == null )
                    {
                        continue;
                    }

                    service.Delete( SdkMessageProcessingStep.EntityLogicalName, d.DependentComponentObjectId.Value );
                    logger.Log( $"SdkMessageProcessingStep '{d.DependentComponentObjectId.Value}' deleted successfully" );
                }
                else
                {
                    throw new InvalidOperationException(
                        $"Unknown DependentComponentValue: {d.DependentComponentType.Value}" );
                }
            }
        }

        /// <summary>
        /// Creates solution with all components of the pluginAssembly in the source system. Then Imports the solution to the destination system
        /// </summary>
        private void SyncPluginStepsViaSolution( Entity sourcePluginAssembly,
                                                 Entity destPluginAssembly,
                                                 string publisher )
        {
            var solutions = RetrieveSpecificSolution( sourceSystem ).ToList( );
            if( solutions.Any( ) )
            {
                DeleteSolution( sourceSystem, solutions.First( ) );
            }

            CreateSolution( sourceSystem, publisher );

            var registeredDestPluginTypes = RetrievePluginTypes( destinationSystem, destPluginAssembly.Id ).ToList( );
            var registeredSourcePluginTypes = RetrievePluginTypes( sourceSystem, sourcePluginAssembly.Id ).ToList( );

            var itemsToAddToSolution = new List< PluginType >( );

            registeredDestPluginTypes.ForEach( destType =>
            {
                var intersectcandidate =
                    registeredSourcePluginTypes.FirstOrDefault( sourceType => sourceType.TypeName == destType.TypeName );
                if( intersectcandidate != null )
                {
                    itemsToAddToSolution.Add( intersectcandidate );
                }
            } );

            AddItemsToSolution( sourceSystem, itemsToAddToSolution );

            var solution = ExportSolution( sourceSystem );
            ImportSolutionInDestination( solution );
        }

        /// <summary>
        /// Delete all registered plugintypes+steps and workflows which are not in the assembly anymore
        /// </summary>
        /// <param name="pluginAssembly"></param>
        private void DeleteOldPluginTypeStepsOfAssembly( Entity pluginAssembly )
        {
            if( pluginAssembly == null )
            {
                return;
            }

            var foundPlugins = SearchForPlugins( ).ToList( );
            var registeredPluginTypes = RetrievePluginTypes( destinationSystem, pluginAssembly.Id ).ToList( );

            // Delete old pluginTypes
            foreach( var pluginType in registeredPluginTypes.Where( pt =>
                                                                        pt.IsWorkflowActivity.HasValue && !pt.IsWorkflowActivity.Value ) )
            {
                if( !foundPlugins.Any( ft => ft.FullName != null && ft.FullName.Equals( pluginType.TypeName ) ) )
                {
                    DeleteStepsByPluginType( pluginType );
                    DeletePluginType( pluginType );
                }
            }

            var foundWorkflows = SearchForWorkflows( ).ToList( );
            // Delete old workflows
            foreach( var pluginType in registeredPluginTypes.Where( pt =>
                                                                        pt.IsWorkflowActivity.HasValue && pt.IsWorkflowActivity.Value ) )
            {
                if( !foundWorkflows.Any( ft => ft.FullName != null && ft.FullName.Equals( pluginType.TypeName ) ) )
                {
                    DeletePluginType( pluginType );
                }
            }
        }


        /// <summary>
        /// Delete all registered plugintypes+steps and workflows which are not in the assembly anymore
        /// </summary>
        /// <param name="pluginAssembly"></param>
        private void DeleteAllPluginTypeStepsOfAssembly( Entity pluginAssembly )
        {
            if( pluginAssembly == null )
            {
                return;
            }

            var registeredPluginTypes = RetrievePluginTypes( destinationSystem, pluginAssembly.Id ).ToList( );

            // Delete old pluginTypes
            foreach( var pluginType in registeredPluginTypes.Where( pt =>
                                                                        pt.IsWorkflowActivity.HasValue && !pt.IsWorkflowActivity.Value ) )
            {
                DeleteStepsByPluginType( pluginType );
                DeletePluginType( pluginType );
            }

            // Delete old workflows
            foreach( var pluginType in registeredPluginTypes.Where( pt =>
                                                                        pt.IsWorkflowActivity.HasValue && pt.IsWorkflowActivity.Value ) )
            {
                DeletePluginType( pluginType );
            }
        }


        private void UpdatePluginAssembly( IOrganizationService service, PluginAssembly pluginAssembly, string content )
        {
            var updatedAssembly = new PluginAssembly
            {
                LogicalName = PluginAssembly.EntityLogicalName,
                Id = pluginAssembly.Id,
                Content = content
            };

            service.Update( updatedAssembly );

            // Necessary because otherwise further steps will fail, because the new plugin content is not 
            // properly loaded in the system.
            PluginAssembly newPluginAssembly;
            var count = 10;
            do
            {
                Thread.Sleep( 100 );
                newPluginAssembly = service.Retrieve( PluginAssembly.EntityLogicalName,
                                                      pluginAssembly.Id,
                                                      new ColumnSet( PluginAssembly.PropertyNames.VersionNumber ) ).ToEntity< PluginAssembly >( );
                count--;
                logger.Log(
                    $"Count: {count}, Old VersionNumber: {pluginAssembly.VersionNumber}, New VersionNumber: {newPluginAssembly.VersionNumber}" );
            }
            while( pluginAssembly.VersionNumber == newPluginAssembly.VersionNumber && count >= 0 );

            logger.Log( "Successfully updated PluginAssembly" );
        }

        /// <summary>
        /// Find all classes of the assembly via reflection which implement the interface IPlugin
        /// </summary>
        /// <returns></returns>
        private IEnumerable< Type > SearchForPlugins( )
        {
            return AssemblyPlugin.ExportedTypes.Where(
                t => t.IsClass
                    && !t.IsAbstract
                    && t.GetInterface( typeof( IPlugin ).FullName ) != null
            );
        }

        /// <summary>
        /// Find all classes of the assembly via reflection which directly inherit from CodeActivity
        /// </summary>
        /// <returns></returns>
        private IEnumerable< Type > SearchForWorkflows( )
        {
            return AssemblyPlugin.ExportedTypes.Where(
                t => t.IsClass
                    && !t.IsAbstract
                    && t.BaseType == typeof( CodeActivity )
            );
        }

        private PluginAssembly CreatePluginAssembly( IOrganizationService service, Assembly assembly, string content )
        {
            var bytes = assembly.GetName( ).GetPublicKeyToken( );
            var publicKeyToken = BitConverter.ToString( bytes ).Replace( "-", "" );

            var pluginAssembly = new PluginAssembly
            {
                LogicalName = PluginAssembly.EntityLogicalName,
                Content = content,
                Name = assembly.GetName( ).Name,
                Culture = assembly.GetName( ).CultureName,
                Version = assembly.GetName( ).Version.ToString( ),
                PublicKeyToken = publicKeyToken,
                SourceType = new OptionSetValue( ( int ) PluginAssembly.OptionSet.SourceType.Database ),
                IsolationMode = new OptionSetValue( ( int ) PluginAssembly.OptionSet.IsolationMode.None )
            };

            var id = service.Create( pluginAssembly );

            logger.Log( $"Successfully created PluginAssembly '{assembly.GetName( ).Name}' with id {id}" );

            pluginAssembly.Id = id;
            return pluginAssembly;
        }

        private void CreatePluginType( IOrganizationService service, Guid pluginAssemblyId, Type type )
        {
            var pluginType = CreatePluginTypeEntity( pluginAssemblyId, type );
            var id = service.Create( pluginType );

            logger.Log( $"Successfully created PluginType '{type.FullName}' with id {id}" );
        }

        private void UpdatePluginType( IOrganizationService service, PluginType existingPluginType, Type type )
        {
            var description = GetDescription( type );

            if( existingPluginType.Description == description ) return;

            var updatePluginType = new PluginType
            {
                Id = existingPluginType.Id,
                Description = description
            };
            service.Update( updatePluginType );
        }

        private PluginType CreatePluginTypeEntity( Guid pluginAssemblyId, Type type )
        {
            var description = GetDescription( type );

            var pluginType = new PluginType
            {
                LogicalName = PluginType.EntityLogicalName,
                PluginAssemblyId = new EntityReference( PluginAssembly.EntityLogicalName, pluginAssemblyId ),
                TypeName = type.FullName,
                FriendlyName = Guid.NewGuid( ).ToString( ),
                Name = type.FullName,
                Description = description
            };
            return pluginType;
        }

        private string GetDescription( Type type )
        {
            var descriptionNode =
                CommentXml.SelectSingleNode( $"doc/members/member[@name=\"T:{type.FullName}\"]/summary" );
            var description = "No description";

            if( descriptionNode != null )
            {
                description = descriptionNode.InnerText.Trim( ' ', '\r', '\n' ).Replace( "\r\n            ", " " );
                if( description.Length > 256 ) description = description.Substring( 0, 256 );
            }

            return description;
        }

        private void DeletePluginType( PluginType pluginType )
        {
            destinationSystem.Delete( PluginType.EntityLogicalName, pluginType.Id );
            logger.Log( $"Successfully deleted PluginType '{pluginType.TypeName}'" );
        }

        private void DeleteSolution( IOrganizationService service, Solution solution )
        {
            service.Delete( "solution", solution.Id );

            logger.Log( $"Successfully deleted Solution '{solution.UniqueName}'" );
        }

        private void CreateSolution( IOrganizationService service, string publisher )
        {
            var solution = new Solution
            {
                LogicalName = Solution.EntityLogicalName,
                FriendlyName = SolutionName,
                UniqueName = SolutionName,
                Version = "1.0.0.0",
                PublisherId = RetrievePublisher( service, publisher ).ToEntityReference( )
            };

            var id = service.Create( solution );

            logger.Log( $"Successfully created Solution '{solution.UniqueName}' with id {id}" );
        }

        private void AddItemsToSolution( IOrganizationService service, List< PluginType > pluginTypes )
        {
            var executeMultipleRequest =
                new ExecuteMultipleRequest
                {
                    Settings = new ExecuteMultipleSettings
                    {
                        ContinueOnError = true,
                        // We don't need responses for succeeded requests, failed requests always return responses
                        ReturnResponses = false
                    },
                    Requests = new OrganizationRequestCollection( )
                };

            pluginTypes.ForEach( pluginType =>
                {
                    foreach( var d in RetrieveSdkStepsByPluginType( service, pluginType ) )
                    {
                        if( d.DependentComponentType.Value ==
                            ( int ) SolutionComponent.OptionSet.ComponentType.SdkMessageProcessingStep
                            || d.DependentComponentType.Value ==
                            ( int ) SolutionComponent.OptionSet.ComponentType.Workflow )
                        {
                            if( d.DependentComponentObjectId != null )
                                executeMultipleRequest.Requests.Add( new AddSolutionComponentRequest
                                {
                                    AddRequiredComponents = false,
                                    ComponentId = d.DependentComponentObjectId.Value,
                                    ComponentType = d.DependentComponentType.Value,
                                    SolutionUniqueName = SolutionName
                                } );
                            executeMultipleRequest.Requests.AddRange( RetrieveDependentComponents( service, d ) );
                        }
                        else
                        {
                            throw new InvalidOperationException(
                                $"Unknown DependentComponentValue: {d.DependentComponentType.Value}" );
                        }
                    }
                }
            );

            if( !executeMultipleRequest.Requests.Any( ) ) return;

            var executeMultipleResponse = ( ExecuteMultipleResponse ) service.Execute( executeMultipleRequest );
            if( executeMultipleResponse.IsFaulted )
            {
                var errorMessages = executeMultipleResponse.Responses
                    .Where( r => r.Fault != null )
                    .Select( r => r.Fault.Message );

                logger.Error( $"Errors occured:\n{string.Join( Environment.NewLine, errorMessages )}" );
            }
            else
            {
                logger.Log( $"Successfully added {executeMultipleRequest.Requests.Count} components to solution" );
            }
        }

        private byte[] ExportSolution( IOrganizationService service )
        {
            var exportSolutionRequest = new ExportSolutionRequest
            {
                Managed = false,
                SolutionName = SolutionName
            };

            var result = ( ExportSolutionResponse ) service.Execute( exportSolutionRequest );

            return result.ExportSolutionFile;
        }

        private void ImportSolutionInDestination( byte[] solutionContent )
        {
            var importSolutionRequest = new ImportSolutionRequest
            {
                CustomizationFile = solutionContent,
                PublishWorkflows = true
            };

            destinationSystem.Execute( importSolutionRequest );
        }


        /// <summary>
        /// Updates destination system according to arguments
        /// Could delete plugins / steps / images
        /// </summary>
        /// <param name="parsedArgs"></param>
        /// <param name="destPluginAssembly"></param>
        public void UpdateSystem( CmdArgs parsedArgs, PluginAssembly destPluginAssembly )
        {
            if( !parsedArgs.Sync )
            {
                try
                {
                    // Update Assembly
                    destPluginAssembly = UploadPluginAssemblyToDestination( destPluginAssembly );
                    // Create NEW PluginTypes/Workflows
                    CreateNewPluginTypesInDestination( destPluginAssembly );
                }
                catch( Exception exception )
                {
                    logger.Error( "Exception on Update of Assembly occured:\n", exception );
                    logger.Error(
                        "Your Assembly differs from Assembly on Destination-System: PluginTypes or Steps do not fit. Please contact colleagues or try Sync Option" );
                }
            }
            else
            {
                if( parsedArgs.SourceSystem == null )
                {
                    // Deletion of old PluginSteps and PluginTypes
                    DeleteOldPluginTypeStepsOfAssembly( destPluginAssembly );
                    // Assembly Update
                    destPluginAssembly = UploadPluginAssemblyToDestination( destPluginAssembly );
                    // Create NEW PluginTypes/Workflows
                    CreateNewPluginTypesInDestination( destPluginAssembly );
                }
                else
                {
                    var sourcePluginAssembly = RetrievePluginAssembly( sourceSystem, AssemblyPlugin.GetName( ).Name );

                    logger.Log( $"SourceSystem is \'{parsedArgs.SourceSystem}\'" );
                    // Delete all Steps in Destination
                    DeleteOldPluginTypeStepsOfAssembly( destPluginAssembly );
                    // Assembly Update or Create
                    destPluginAssembly = UploadPluginAssemblyToDestination( destPluginAssembly );
                    // Create NEW PluginTypes/Workflows
                    CreateNewPluginTypesInDestination( destPluginAssembly );
                    // Sync Steps from Source to Destination
                    SyncPluginStepsViaSolution( sourcePluginAssembly, destPluginAssembly, parsedArgs.Publisher );

                    logger.Log( "Successfully imported solution" );
                }
            }
        }

        /// <summary>
        /// Create plugins / steps / images of an assembly from scratch
        /// Based on VS project
        /// </summary>
        /// <param name="parsedArgs"></param>
        /// <param name="destPluginAssembly"></param>
        public void CreateFromScratch( CmdArgs parsedArgs, PluginAssembly destPluginAssembly )
        {
            var uow = new CrmUnitOfWork( destinationSystem );

            // Delete destination assembly
            DeleteAllPluginTypeStepsOfAssembly( destPluginAssembly );

            // Create / Update assembly
            destPluginAssembly = UploadPluginAssemblyToDestination( destPluginAssembly );

            // Create NEW PluginTypes/Workflows
            CreateNewPluginTypesInDestination( destPluginAssembly );

            // Create Steps
            var file = new FileInfo( parsedArgs.AssemblyPath );
            var assemblyName = file.Name.Substring( 0, file.Name.Length - 4 );

            var plugin = ( from pl in uow.PluginAssemblies.GetQuery( )
                where pl.Name == assemblyName
                select pl ).SingleOrDefault( );

            var steps = ( from st in uow.SdkMessageProcessingSteps.GetQuery( )
                join pt in uow.PluginTypes.GetQuery( ) on st.EventHandler.Id equals pt.PluginTypeId
                where pt.PluginAssemblyId.Id == plugin.PluginAssemblyId
                select st ).ToArray( ).ToDictionary( s => s.UniqueName );

            var stepsToCreate = CreateStepsModel( assemblyName );
            CreateSteps( uow, plugin, steps, stepsToCreate );

            // Create Images
            var allImages = ( from im in uow.SdkMessageProcessingStepImages.GetQuery( )
                join st in uow.SdkMessageProcessingSteps.GetQuery( ) on im.SdkMessageProcessingStepId.Id equals st.SdkMessageProcessingStepId
                join pl in uow.PluginTypes.GetQuery( ) on st.EventHandler.Id equals pl.PluginTypeId
                where pl.PluginAssemblyId.Id == plugin.PluginAssemblyId
                select im ).ToList( );

            CreateImages( uow, stepsToCreate, allImages, steps );

            logger.Log(
                $"Successfully created steps and images of Plugin {AssemblyPlugin.GetName( ).Name} in {destinationSystem}." );
        }

        private List< Step > CreateStepsModel( string assemblyName )
        {
            var ns = assemblyName + ".Attributes.";
            var stepAttributeType = AssemblyPlugin.GetType( ns + "StepAttribute" );

            var pluginType = typeof( IPlugin );
            var classes = ( from cl in AssemblyPlugin.GetTypes( )
                where pluginType.IsAssignableFrom( cl ) && !cl.IsAbstract
                select cl ).ToList( );

            var stepsToCreate = new List< Step >( );
            classes.ForEach( cl =>
            {
                var assmSteps = cl.GetCustomAttributes( stepAttributeType, false ).ToArray( );

                if( assmSteps.Length > 0 )
                {
                    foreach( var assStep in assmSteps )
                    {
                        var stepToCreate = new Step
                        {
                            Class = cl, EventType = ( CrmEventType ) Enum.Parse( typeof( CrmEventType ), stepAttributeType.GetProperty( nameof(Step.EventType) ).GetValue( assStep ).ToString( ) ),
                            ExecutionOrder = ( int ) stepAttributeType.GetProperty( nameof(Step.ExecutionOrder) ).GetValue( assStep ),
                            FilteringAttributes = ( string[] ) stepAttributeType.GetProperty( nameof(Step.FilteringAttributes) ).GetValue( assStep ),
                            PreImage = ( bool ) stepAttributeType.GetProperty( nameof(Step.PreImage) ).GetValue( assStep ),
                            PostImage = ( bool ) stepAttributeType.GetProperty( nameof(Step.PostImage) ).GetValue( assStep ),
                            ImageName = ( string ) stepAttributeType.GetProperty( nameof(Step.ImageName) ).GetValue( assStep ),
                            ImageAttributes = ( string[] ) stepAttributeType.GetProperty( nameof(Step.ImageAttributes) ).GetValue( assStep ),
                            PrimaryEntity = ( string ) stepAttributeType.GetProperty( nameof(Step.PrimaryEntity) ).GetValue( assStep ),
                            SecondaryEntity = ( string ) stepAttributeType.GetProperty( nameof(Step.SecondaryEntity) ).GetValue( assStep ),
                            Offline = ( bool ) stepAttributeType.GetProperty( nameof(Step.Offline) ).GetValue( assStep )
                        };

                        if( stepToCreate.ExecutionOrder == 0 )
                        {
                            stepToCreate.ExecutionOrder = 1;
                        }

                        stepsToCreate.Add( stepToCreate );
                    }
                }
                else
                {
                    logger.Error( cl.FullName + " is missing step or solution" );
                }
            } );
            return stepsToCreate;
        }

        private void CreateSteps( UnitOfWork.UnitOfWork uow,
                                  PluginAssembly plugin,
                                  IDictionary< string, SdkMessageProcessingStep > steps,
                                  IReadOnlyCollection< Step > stepsToCreate )
        {
            var pluginTypes = ( from pl in uow.PluginTypes.GetQuery( )
                where pl.PluginAssemblyId.Id == plugin.PluginAssemblyId
                select pl ).ToArray( ).ToDictionary( t => t.TypeName );


            var sdkMessageIndex = ( from s in uow.SdkMessages.GetQuery( ) select s ).ToArray( ).ToDictionary( s => s.Name );
            
            foreach( var step in stepsToCreate )
            {
                var sdkMessage = sdkMessageIndex[ step.EventType.ToString( ) ];

                SdkMessageFilter filter;

                if( string.IsNullOrEmpty( step.SecondaryEntity ) )
                {
                    filter = ( from f in uow.SdkMessageFilters.GetQuery( )
                        where f.SdkMessageId.Id == sdkMessage.SdkMessageId
                            && f.PrimaryObjectTypeCode == step.PrimaryEntity
                        select f ).SingleOrDefault( );
                }
                else
                {
                    filter = ( from f in uow.SdkMessageFilters.GetQuery( )
                        where f.SdkMessageId.Id == sdkMessage.SdkMessageId
                            && f.PrimaryObjectTypeCode == step.PrimaryEntity
                            && f.SecondaryObjectTypeCode == step.SecondaryEntity
                        select f ).SingleOrDefault( );
                }

                var deployment = 0;
                if( step.Offline )
                {
                    deployment = 2;
                }


                var newStep = new SdkMessageProcessingStep
                {
                    SdkMessageProcessingStepId = Guid.NewGuid( ),
                    Name = step.Name,
                    Mode = new OptionSetValue( step.Async ),
                    Rank = step.ExecutionOrder,
                    Stage = new OptionSetValue( step.StageValue ),
                    SupportedDeployment = new OptionSetValue( deployment ),
                    EventHandler = pluginTypes[ step.Class.FullName ].ToEntityReference( ),
                    SdkMessageId = sdkMessageIndex[ step.EventType.ToString( ) ].ToEntityReference( ),
                    SdkMessageFilterId = filter?.ToEntityReference( ),
                };

                if( step.Stage == StageEnum.PostOperationAsyncWithDelete )
                {
                    newStep.AsyncAutoDelete = true;
                }


                uow.Create( newStep );
                steps.Add( newStep.UniqueName, newStep );
                logger.Log( "Added step: " + newStep.Name );
            }

            var edits = ( from s in stepsToCreate where steps.ContainsKey( s.UniqueName ) select s ).ToArray( );
            foreach( var edit in edits )
            {
                var step = steps[ edit.UniqueName ];
                var deployment = 0;

                if( edit.Offline )
                {
                    deployment = 2;
                }

                if( step.SupportedDeployment.Value != deployment )
                {
                    var clean = uow.SdkMessageProcessingSteps.Clean( step );
                    clean.SupportedDeployment = new OptionSetValue( deployment );
                    uow.Update( clean );
                    Console.WriteLine( "Changed supported deployment for " + edit.Name + " > " + deployment );
                }

                if( edit.Stage == StageEnum.PostOperationAsyncWithDelete && !( step.AsyncAutoDelete ?? false ) )
                {
                    var clean = uow.SdkMessageProcessingSteps.Clean( step );
                    clean.AsyncAutoDelete = true;
                    uow.Update( clean );
                    Console.WriteLine( "Changed async delete policy deployment for " + edit.Name + " > " + deployment );
                }
                else if( edit.Stage == StageEnum.PostOperationAsyncWithoutDelete && ( step.AsyncAutoDelete ?? false ) )
                {
                    var clean = uow.SdkMessageProcessingSteps.Clean( step );
                    clean.AsyncAutoDelete = false;
                    uow.Update( clean );
                    Console.WriteLine( "Changed async deployment for " + edit.Name + " > " + deployment );
                }
            }
        }


        private static void CreateImages( UnitOfWork.UnitOfWork uow,
                                          IEnumerable< Step > stepsToCreate,
                                          IReadOnlyCollection< SdkMessageProcessingStepImage > allImages,
                                          IReadOnlyDictionary< string, SdkMessageProcessingStep > stepindex )
        {
            foreach( var step in stepsToCreate )
            {
                var xrmStep = stepindex[ step.UniqueName ];
                var images = (
                    from im in allImages
                    where xrmStep.SdkMessageProcessingStepId != null && im.SdkMessageProcessingStepId.Id == xrmStep.SdkMessageProcessingStepId.Value
                    select im );

                images.ForEach( image =>
                {
                    if( image == null )
                    {
                        var imageToCreate = new SdkMessageProcessingStepImage
                        {
                            SdkMessageProcessingStepImageId = Guid.NewGuid( ),
                            SdkMessageProcessingStepId = xrmStep.ToEntityReference( ),
                            Name = step.ImageName,
                            EntityAlias = step.ImageName,
                            MessagePropertyName = step.MessagePropertyName,
                            ImageType = step.PreImage ? new OptionSetValue( 0 ) : new OptionSetValue( 1 ),
                            Description = step.ImageName,
                            Relevant = true,
                            Attributes1 = step.ImageAttributes != null && step.ImageAttributes.Length > 0
                                ? string.Join( ",", step.ImageAttributes )
                                : null
                        };
                        uow.Create( imageToCreate );
                        if( step.PreImage )
                        {
                            Console.WriteLine($"Pre Image {step.ImageName} created " + step.Name);
                        }
                        else
                        {
                            Console.WriteLine($"Post Image {step.ImageName} created " + step.Name);
                        }
                    }
                    else
                    {
                        var clean = uow.SdkMessageProcessingStepImages.Clean( image );

                        var preAtr = step.ImageAttributes == null || step.ImageAttributes.Length == 0
                            ? null
                            : string.Join( ",", step.ImageAttributes );

                        if( preAtr != image.Attributes1 )
                        {
                            clean.Attributes1 = preAtr;
                            uow.Update( clean );
                            if( step.PreImage )
                            {
                                Console.WriteLine( "Pre image updated " + step.Name + " :" + preAtr );
                            }
                            else
                            {
                                Console.WriteLine( "Post image updated " + step.Name + " :" + preAtr );
                            }
                        }

                        image.Relevant = true;
                    }
                } );
            }

            var notNeededs = ( from im in allImages where im.Relevant == false select im ).ToArray( );
            foreach( var notNeeded in notNeededs )
            {
                uow.Delete( notNeeded );
                Console.WriteLine( "Image deleted for " + notNeeded.Name );
            }
        }

        /// <summary>
        /// Fetch the pluginassembly from the given service
        /// </summary>
        /// <param name="service"></param>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public PluginAssembly RetrievePluginAssembly( IOrganizationService service, string assemblyName )
        {
            var fetchXml =
                $@"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false' no-lock='true'>
                    <entity name='{PluginAssembly.EntityLogicalName}'>
		                <attribute name='{PluginAssembly.PropertyNames.PluginAssemblyId}' />
                        <attribute name='{PluginAssembly.PropertyNames.VersionNumber}' />
		                <filter type='and'>
			                <condition attribute='{PluginAssembly.PropertyNames.ComponentState}' operator='eq' value='{( int ) PluginAssembly.OptionSet.ComponentState.Published}'/>
			                <condition attribute='{PluginAssembly.PropertyNames.Name}' operator='eq' value='{assemblyName}'/>
		                </filter>
	                </entity>
                </fetch>";

            var result = service.RetrieveMultiple( new FetchExpression( fetchXml ) );

            if( result.Entities.Count != 1 )
            {
                return null;
            }

            var pluginAssembly = result.Entities.First( ).ToEntity< PluginAssembly >( );
            logger.Log( $"Found assembly with id {pluginAssembly.Id}" );

            return pluginAssembly;
        }

        private IEnumerable< PluginType > RetrievePluginTypes( IOrganizationService service, Guid pluginAssemblyId )
        {
            var fetchXml =
                $@"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false' no-lock='true'>
	                <entity name='{PluginType.EntityLogicalName}'>
		                <attribute name='{PluginType.PropertyNames.PluginTypeId}' />
		                <attribute name='{PluginType.PropertyNames.TypeName}' />
                        <attribute name='{PluginType.PropertyNames.IsWorkflowActivity}' />
                        <attribute name='{PluginType.PropertyNames.Description}' />
		                <filter type='and'>
			                <condition attribute='{PluginType.PropertyNames.PluginAssemblyId}' operator='eq' value='{pluginAssemblyId}'/>
			                <condition attribute='{PluginType.PropertyNames.ComponentState}' operator='eq' value='{( int ) PluginType.OptionSet.ComponentState.Published}'/>
		                </filter>
	                </entity>
                </fetch>";

            var response = service.RetrieveMultiple( new FetchExpression( fetchXml ) );

            return response.Entities.Select( e => e.ToEntity< PluginType >( ) );
        }

        private IEnumerable< Solution > RetrieveSpecificSolution( IOrganizationService service )
        {
            var fetchXml =
                $@"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false' no-lock='true'>
	                <entity name='{Solution.EntityLogicalName}'>
		                <attribute name='{Solution.PropertyNames.SolutionId}' />
		                <attribute name='{Solution.PropertyNames.UniqueName}' />
		                <filter type='and'>
			                <condition attribute='{Solution.PropertyNames.UniqueName}' operator='eq' value='{SolutionName}'/>
		                </filter>
	                </entity>
                </fetch>";

            var response = service.RetrieveMultiple( new FetchExpression( fetchXml ) );

            return response.Entities.Select( e => e.ToEntity< Solution >( ) );
        }

        private Publisher RetrievePublisher( IOrganizationService service, string publisher )
        {
            var fetchXml =
                $@"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false' no-lock='true'>
	                <entity name='{Publisher.EntityLogicalName}'>
		                <attribute name='{Publisher.PropertyNames.PublisherId}' />
		                <attribute name='{Publisher.PropertyNames.UniqueName}' />
		                <filter type='and'>
			                <condition attribute='{Publisher.PropertyNames.UniqueName}' operator='eq' value='{publisher}'/>
		                </filter>
	                </entity>
                </fetch>";

            var response = service.RetrieveMultiple( new FetchExpression( fetchXml ) );

            return response.Entities.First( ).ToEntity< Publisher >( );
        }

        private static IEnumerable< Dependency > RetrieveSdkStepsByPluginType( IOrganizationService service,
                                                                               Entity pluginType )
        {
            var retrieveDependenciesForDeleteRequest = new RetrieveDependenciesForDeleteRequest
            {
                ComponentType = ( int ) SolutionComponent.OptionSet.ComponentType.PluginType,
                ObjectId = pluginType.Id
            };

            var response =
                ( RetrieveDependenciesForDeleteResponse ) service.Execute( retrieveDependenciesForDeleteRequest );

            return response.EntityCollection.Entities.Select( e => e.ToEntity< Dependency >( ) );
        }

        private IEnumerable< OrganizationRequest > RetrieveDependentComponents( IOrganizationService service,
                                                                                Dependency dependency )
        {
            if( dependency.DependentComponentObjectId == null )
            {
                yield break;
            }

            var retrieveRequiredComponentsRequest = new RetrieveRequiredComponentsRequest( )
            {
                ComponentType = dependency.DependentComponentType.Value,
                ObjectId = dependency.DependentComponentObjectId.Value
            };

            var response = ( RetrieveRequiredComponentsResponse ) service.Execute( retrieveRequiredComponentsRequest );

            foreach( var dep in response.EntityCollection.Entities.Select( e => e.ToEntity< Dependency >( ) ) )
            {
                if( dep.RequiredComponentType.Value != ( int ) Dependency.OptionSet.ComponentType.Workflow )
                {
                    continue;
                }

                if( dep.RequiredComponentObjectId != null )
                    yield return new AddSolutionComponentRequest
                    {
                        AddRequiredComponents = false,
                        ComponentType = dep.RequiredComponentType.Value,
                        ComponentId = dep.RequiredComponentObjectId.Value,
                        SolutionUniqueName = SolutionName
                    };
            }
        }
    }
}