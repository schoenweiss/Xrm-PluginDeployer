namespace Xrm.PluginDeployer.Entities
{
    public partial class SdkMessageProcessingStep
    {
        /// <summary>
        /// Name/Stage/Rank/Mode/AsyncAutoDelete
        /// </summary>
        public string UniqueName
        {
            get
            {
                return this.Name + "/" + this.Stage.Value + "/" + this.Rank + "/"  + this.Mode.Value.ToString();
            }
        }
    }
}
