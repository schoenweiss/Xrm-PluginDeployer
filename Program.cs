using System;
using Microsoft.Xrm.Sdk;
using PowerArgs;
using Xrm.PluginDeployer.Utility;

namespace Xrm.PluginDeployer
{
    /// <summary>
    /// Runs Plugin Deployer
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Here it all begins
        /// </summary>
        /// <param name="args"></param>
        public static void Main( string[] args )
        {
            var log = new ConsoleLogger( typeof( Program ) );

            CmdArgs parsedArgs;
            try
            {
                parsedArgs = Args.Parse< CmdArgs >( args );
            }
            catch( ArgException e )
            {
                Console.WriteLine( ArgUsage.GenerateUsageFromTemplate< CmdArgs >( ) );
                log.Error( $"Failed to parse arguments: {e.Message}" );
                return;
            }

            try
            {
                IOrganizationService sourceService = null;
                var destinationSystem = parsedArgs.DestinationSystem;
                IOrganizationService destinationService = OrganizationServiceFactory.ConnectByConnectionString( destinationSystem );
                if( parsedArgs.SourceSystem != null )
                {
                    sourceService = OrganizationServiceFactory.ConnectByConnectionString( parsedArgs.SourceSystem + "RequireNewInstance = True;" );
                }

                var deployer = new PluginDeployer( sourceService, destinationService, parsedArgs.Prefix, log );

                if( !deployer.LoadAssembly( parsedArgs.AssemblyPath ) )
                {
                    return;
                }

                var assemblyName = deployer.AssemblyPlugin.GetName( ).Name;
                var destinationAssembly = deployer.RetrievePluginAssembly( destinationService, assemblyName );

                var createFromScratch = parsedArgs.Create;

                if( createFromScratch )
                {
                    deployer.CreateFromScratch( parsedArgs, destinationAssembly );
                }
                else
                {
                    deployer.UpdateSystem( parsedArgs, destinationAssembly );
                }
            }
            catch( Exception ex )
            {
                log.Error( $"Exception occured, terminating. Exception: {GetAllExceptionMessages( ex )}\n\n" );
                log.Error( $"Stacktrace: {ex.StackTrace}" );
            }
        }


        private static string GetAllExceptionMessages( Exception ex )
        {
            return ex == null ? string.Empty : $"{ex.Message}{GetAllExceptionMessages( ex.InnerException )}";
        }
    }
}
