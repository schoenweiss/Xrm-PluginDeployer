using System;
using Microsoft.Xrm.Sdk;
using Xrm.PluginDeployer.Entities;

namespace Xrm.PluginDeployer.UnitOfWork
{
    /// <summary>
    /// Wrapper class for the Organisation Service and needed operations
    /// </summary>
    public class CrmUnitOfWork: UnitOfWork
    {
        private readonly CrmContext context;
        private IOrganizationService Service { get; set; }
        private IOrganizationServiceFactory ServiceFactory { get; set; }

        /// <summary>
        /// Creates a wrapper class for the Organisation Service
        /// </summary>
        /// <param name="service"></param>
        public CrmUnitOfWork( IOrganizationService service )
        {
            Service = service;
            context = new CrmContext( Service );
        }

        /// <summary>
        /// Disposes of the service context
        /// </summary>
        public void Dispose( )
        {
            context.Dispose( );
        }

        /// <summary>
        /// Saves the changes that the OrganizationServiceContext is tracking to Microsoft Dynamics 365.
        /// </summary>
        public void SaveChanges( )
        {
            context.SaveChanges( );
        }

        /// <summary>
        /// Executes a CRM request.
        /// </summary>
        /// <param name="request">Request to execute.</param>
        public T ExecuteRequest< T >( OrganizationRequest request ) where T : OrganizationResponse
        {
            return ( T ) context.Execute( request );
        }

        /// <summary>
        /// Executes a message in the form of a request, and returns a response.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public OrganizationResponse Execute( OrganizationRequest request )
        {
            return context.Execute( request );
        }

        /// <summary>
        /// Executes a message in the form of a request, and returns a response.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="runAsSystemUserId"></param>
        /// <returns></returns>
        public OrganizationResponse Execute( OrganizationRequest request, Guid runAsSystemUserId )
        {
            var ser = ServiceFactory.CreateOrganizationService( runAsSystemUserId );
            return ser.Execute( request );
        }

        /// <summary>
        /// Creates a record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Guid Create( Entity entity )
        {
            return Service.Create( entity );
        }

        /// <summary>
        /// Updates a record.
        /// </summary>
        /// <param name="entity"></param>
        public void Update( Entity entity )
        {
            Service.Update( entity );
        }

        /// <summary>
        /// Deletes a record
        /// </summary>
        /// <param name="entity"></param>
        public void Delete( Entity entity )
        {
            Service.Delete( entity.LogicalName, entity.Id );
        }

        private Repository< Solution > solutions;
        public Repository< Solution > Solutions => solutions ?? ( solutions = new CrmRepository< Solution >( context ) );

        private Repository< SolutionComponent > solutioncomponents;
        public Repository< SolutionComponent > SolutionComponents => solutioncomponents ?? ( solutioncomponents = new CrmRepository< SolutionComponent >( context ) );

        private Repository< PluginAssembly > pluginAssemblies;
        public Repository< PluginAssembly > PluginAssemblies => pluginAssemblies ?? ( pluginAssemblies = new CrmRepository< PluginAssembly >( context ) );

        private Repository< SdkMessageProcessingStep > sdkMessageProcessingSteps;
        public Repository< SdkMessageProcessingStep > SdkMessageProcessingSteps => sdkMessageProcessingSteps ?? ( sdkMessageProcessingSteps = new CrmRepository< SdkMessageProcessingStep >( context ) );

        private Repository< SdkMessageProcessingStepImage > sdkMessageProcessingStepImages;
        public Repository< SdkMessageProcessingStepImage > SdkMessageProcessingStepImages => sdkMessageProcessingStepImages ?? ( sdkMessageProcessingStepImages = new CrmRepository< SdkMessageProcessingStepImage >( context ) );

        private Repository< PluginType > plugintypes;
        public Repository< PluginType > PluginTypes => plugintypes ?? ( plugintypes = new CrmRepository< PluginType >( context ) );

        private Repository< SdkMessage > sdkMessages;
        public Repository< SdkMessage > SdkMessages => sdkMessages ?? ( sdkMessages = new CrmRepository< SdkMessage >( context ) );

        private Repository< SdkMessageFilter > sdkMessageFilters;
        public Repository< SdkMessageFilter > SdkMessageFilters => sdkMessageFilters ?? ( sdkMessageFilters = new CrmRepository< SdkMessageFilter >( context ) );

        /// <summary>
        /// Clears all tracking of entities by the OrganizationServiceContext.
        /// </summary>
        public void ClearChanges( )
        {
            context.ClearChanges( );
        }
    }
}
