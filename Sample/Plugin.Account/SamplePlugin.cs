using System;
using Microsoft.Xrm.Sdk;
using Xrm.PluginDeployer.References.StepModel;

namespace Plugin.Account
{
    [ Step(
        EventType = CrmEventType.Update,
        PrimaryEntity = "account",
        Stage = StageEnum.PostOperation,
        FilteringAttributes = new[] { "accountname" },
        ExecutionOrder = 1,
        PreImageName = "account",
        PreImageAttributes = new[] { "accountname" },
        PostImageName = "account",
        PostImageAttributes = new[] { "accountname" } ) ]
    // ReSharper disable once UnusedMember.Global
    public class SamplePlugin: IPlugin
    {
        public void Execute( IServiceProvider serviceProvider )
        {
            var pluginExecutionContext =
                ( IPluginExecutionContext ) serviceProvider.GetService( typeof( IPluginExecutionContext ) );

            var service = ( IOrganizationService ) serviceProvider.GetService( typeof( IOrganizationService ) );

            var target = pluginExecutionContext.InputParameters[ "Target" ] as Entity;

            target[ "accountname" ] = "Account name for test sample";

            service.Update( target );
        }
    }
}
