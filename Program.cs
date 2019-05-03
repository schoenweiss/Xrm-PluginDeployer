using System;
using Microsoft.Xrm.Sdk;
using PowerArgs;
using Xrm.PluginDeployer.Utility.Tooling;

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
        public static void Main(string[] args)
        {
            var logger = new ConsoleLogger(typeof(Program));

            CmdArgs parsedArgs;
            try
            {
                parsedArgs = Args.Parse<CmdArgs>(args);
            }
            catch (ArgException e)
            {
                Console.WriteLine(ArgUsage.GenerateUsageFromTemplate<CmdArgs>());
                logger.Error($"Failed to parse arguments: {e.Message}");
                return;
            }

            try
            {
                IOrganizationService sourceService = null;
                var destinationSystem = parsedArgs.DestinationSystem;
                IOrganizationService destinationService =
                    OrganizationServiceFactory.ConnectByConnectionString(destinationSystem);
                if (parsedArgs.SourceSystem != null)
                {
                    sourceService =
                        OrganizationServiceFactory.ConnectByConnectionString(
                            parsedArgs.SourceSystem + "RequireNewInstance = True;");
                }

                var deployer = new PluginDeployer(sourceService, destinationService,
                    parsedArgs.Prefix, logger);

                if (!deployer.LoadAssembly(parsedArgs.AssemblyPath)) return;

                var assemblyName = deployer.AssemblyPlugin.GetName().Name;
                var destPluginAssembly = deployer.RetrievePluginAssembly(destinationService, assemblyName);

                var createFromScratch = parsedArgs.Create;

                if (createFromScratch)
                {
                    deployer.CreateFromScratch(parsedArgs, destPluginAssembly);
                }
                else
                {
                    deployer.UpdateSystem(parsedArgs, destPluginAssembly);
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Exception occured, terminating. Exception: {GetAllExceptionMessages(ex)}\n\n");
                logger.Error($"Stacktrace: {ex.StackTrace}");
            }
        }


        private static string GetAllExceptionMessages(Exception ex)
        {
            if (ex == null)
            {
                return string.Empty;
            }

            return $"{ex.Message}{GetAllExceptionMessages(ex.InnerException)}";
        }
    }
}
