using PowerArgs;

namespace Xrm.PluginDeployer
{
    public class CmdArgs
    {
        [ ArgRequired,ArgDescription( "Full path to Assembly (e.g. C:\\PathToAssembly\\Plugin.Account.dll" ) ]
        public string AssemblyPath { get; set; }

        [ ArgDescription( "CRM ConnectionString to the source system." ) ]
        public string SourceSystem { get; set; }

        [ ArgRequired, ArgDescription("CRM ConnectionString to the destination system. If this string is given, the PluginType and SdkMessageProcessingSteps will be synchronized.")]
        public string DestinationSystem { get; set; }

        [ ArgDescription( "Sync Steps: (Old) steps will be deleted" ), ArgDefaultValue(false) ]
        public bool Sync { get; set; }

        [ ArgDescription("Creates assembly its plugins, steps and images in destination system"), ArgDefaultValue(false)]
        public bool Create { get; set; }

        [ ArgDescription("If Sync was set to true a solution will be created. Choose prefix of this solution here.")]
        public string Prefix { get; set; }

        [ ArgDescription("Publisher needed to create and transport sync solution"), ArgDefaultValue("DefaultPublisher") ]
        public string Publisher { get; set; }
    }
}
