namespace Xrm.PluginDeployer.Entities
{
    public partial class SdkMessageProcessingStep
    {
        /// <summary>
        /// Name/Stage/Rank/Mode/AsyncAutoDelete
        /// </summary>
        public string UniqueName => Name + "/" + Stage.Value + "/" + Rank + "/"  + Mode.Value;
    }
}
