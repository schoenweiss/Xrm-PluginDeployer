using System;
using Microsoft.Xrm.Sdk;
using Xrm.PluginDeployer.References.StepModel;

namespace Plugin.Account
{
    [ Step(
        EventType = CrmEventType.Update,
        PrimaryEntity = "account",
        Stage = StageEnum.PostOperation,
        FilteringAttributes = new[] { "name" },
        ExecutionOrder = 1,
        PreImageName = "account",
        PreImageAttributes = new[] { "name" },
        PostImageName = "account",
        PostImageAttributes = new[] { "name" } ) ]
    [Step(
        EventType = CrmEventType.Create,
        PrimaryEntity = "account",
        Stage = StageEnum.PreOperation,
        FilteringAttributes = new[] { "name" },
        ExecutionOrder = 31,
        PostImageName = "accountCreate",
        PostImageAttributes = new[] { "name" })]
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
