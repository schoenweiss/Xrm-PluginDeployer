namespace Xrm.PluginDeployer.Entities
{

    /// <summary>
    /// Represents a source of entities bound to a CRM service. It tracks and manages changes made to the retrieved entities.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("CrmSvcUtil", "8.2.1.8676")]
    public partial class ContextService : Microsoft.Xrm.Sdk.Client.OrganizationServiceContext
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        public ContextService(Microsoft.Xrm.Sdk.IOrganizationService service) :
                base(service)
        {
        }

        /// <summary>
        /// Gets a binding to the set of all <see cref="Xrm.PluginDeployer.Entities.PluginAssembly"/> entities.
        /// </summary>
        public System.Linq.IQueryable<Xrm.PluginDeployer.Entities.PluginAssembly> PluginAssemblySet
        {
            get
            {
                return this.CreateQuery<Xrm.PluginDeployer.Entities.PluginAssembly>();
            }
        }

        /// <summary>
        /// Gets a binding to the set of all <see cref="Xrm.PluginDeployer.Entities.PluginType"/> entities.
        /// </summary>
        public System.Linq.IQueryable<Xrm.PluginDeployer.Entities.PluginType> PluginTypeSet
        {
            get
            {
                return this.CreateQuery<Xrm.PluginDeployer.Entities.PluginType>();
            }
        }

        /// <summary>
        /// Gets a binding to the set of all <see cref="Xrm.PluginDeployer.Entities.SdkMessage"/> entities.
        /// </summary>
        public System.Linq.IQueryable<Xrm.PluginDeployer.Entities.SdkMessage> SdkMessageSet
        {
            get
            {
                return this.CreateQuery<Xrm.PluginDeployer.Entities.SdkMessage>();
            }
        }

        /// <summary>
        /// Gets a binding to the set of all <see cref="Xrm.PluginDeployer.Entities.SdkMessageFilter"/> entities.
        /// </summary>
        public System.Linq.IQueryable<Xrm.PluginDeployer.Entities.SdkMessageFilter> SdkMessageFilterSet
        {
            get
            {
                return this.CreateQuery<Xrm.PluginDeployer.Entities.SdkMessageFilter>();
            }
        }

        /// <summary>
        /// Gets a binding to the set of all <see cref="Xrm.PluginDeployer.Entities.SdkMessageProcessingStep"/> entities.
        /// </summary>
        public System.Linq.IQueryable<Xrm.PluginDeployer.Entities.SdkMessageProcessingStep> SdkMessageProcessingStepSet
        {
            get
            {
                return this.CreateQuery<Xrm.PluginDeployer.Entities.SdkMessageProcessingStep>();
            }
        }

        /// <summary>
        /// Gets a binding to the set of all <see cref="Xrm.PluginDeployer.Entities.SdkMessageProcessingStepImage"/> entities.
        /// </summary>
        public System.Linq.IQueryable<Xrm.PluginDeployer.Entities.SdkMessageProcessingStepImage> SdkMessageProcessingStepImageSet
        {
            get
            {
                return this.CreateQuery<Xrm.PluginDeployer.Entities.SdkMessageProcessingStepImage>();
            }
        }

        /// <summary>
        /// Gets a binding to the set of all <see cref="Xrm.PluginDeployer.Entities.Solution"/> entities.
        /// </summary>
        public System.Linq.IQueryable<Xrm.PluginDeployer.Entities.Solution> SolutionSet
        {
            get
            {
                return this.CreateQuery<Xrm.PluginDeployer.Entities.Solution>();
            }
        }

        /// <summary>
        /// Gets a binding to the set of all <see cref="Xrm.PluginDeployer.Entities.SolutionComponent"/> entities.
        /// </summary>
        public System.Linq.IQueryable<Xrm.PluginDeployer.Entities.SolutionComponent> SolutionComponentSet
        {
            get
            {
                return this.CreateQuery<Xrm.PluginDeployer.Entities.SolutionComponent>();
            }
        }
    }
}
