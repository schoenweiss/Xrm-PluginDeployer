using PowerArgs;

namespace Xrm.PluginDeployer
{
    public class CmdArgs
    {
        [ ArgRequired, ArgDescription( "Path to Assembly dll" ) ]
        public string AssemblyPath { get; set; }

        [ ArgDescription(
            "CRM-ConnectionString to source system. If this string is given, the Plugins, Steps and Images will be synchronized." ) ]
        public string SourceSystem { get; set; }

        [ ArgRequired, ArgDescription( "CRM-ConnectionString to the destination system." ) ]
        public string DestinationSystem { get; set; }

        [ ArgDescription( "Syncs steps and images. (Old) steps will be deleted" ), ArgDefaultValue( false ) ]
        public bool Sync { get; set; }

        [ ArgDescription( "Creates assembly, its plugins, steps and images in destination system" ),
          ArgDefaultValue( false ) ]
        public bool Create { get; set; }

        [ ArgDescription( "If Sync was set to true a solution will be created. Choose prefix of this solution here." ),
          ArgDefaultValue( "PluginDeployer" ) ]
        public string Prefix { get; set; }

        [ ArgDescription( "Publisher needed to create and transport solution" ), ArgDefaultValue( "DefaultPublisher" ) ]
        public string Publisher { get; set; }
    }
}

