//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Xrm.PluginDeployer.Entities
{
    /// <summary>
    /// Stage in the execution pipeline that a plug-in is to execute.
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute()]
    [Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("sdkmessageprocessingstep")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xrm.PluginDeployer.DevTool.BackEndEarlyBind", "1.0")]
    public partial class SdkMessageProcessingStep : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public SdkMessageProcessingStep() : 
                base(EntityLogicalName)
        {
        }

        /// <summary/>
        public const string EntityLogicalName = "sdkmessageprocessingstep";
        
        /// <summary/>
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        /// <summary/>
        public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
        
        /// <summary/>
        private void OnPropertyChanged(string propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary/>
        private void OnPropertyChanging(string propertyName)
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, new System.ComponentModel.PropertyChangingEventArgs(propertyName));
            }
        }


        /// <summary>
        /// Indicates whether the asynchronous system job is automatically deleted on completion.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("asyncautodelete")]
        public System.Nullable<bool> AsyncAutoDelete
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("asyncautodelete");
            }
            set
            {
                this.OnPropertyChanging("AsyncAutoDelete");
                this.SetAttributeValue("asyncautodelete", value);
                this.OnPropertyChanged("AsyncAutoDelete");
            }
        }
        /// <summary>
        /// AsyncAutoDelete as Enum
        /// </summary>
        public System.Nullable<Xrm.PluginDeployer.Entities.SdkMessageProcessingStep.OptionSet.Sdkmessageprocessingstep_Asyncautodelete> AsyncAutoDeleteAsEnum
        {
            get
            {
                if (!AsyncAutoDelete.HasValue) return null;
                if (AsyncAutoDelete.Value) return Xrm.PluginDeployer.Entities.SdkMessageProcessingStep.OptionSet.Sdkmessageprocessingstep_Asyncautodelete.Yes;
                return Xrm.PluginDeployer.Entities.SdkMessageProcessingStep.OptionSet.Sdkmessageprocessingstep_Asyncautodelete.No;
            }
            set
            {
                if (!value.HasValue) this.SetAttributeValue("asyncautodelete", null);
                if (value.Value == Xrm.PluginDeployer.Entities.SdkMessageProcessingStep.OptionSet.Sdkmessageprocessingstep_Asyncautodelete.Yes)
                {
                    this.SetAttributeValue("asyncautodelete", true);
                }
                else
                {
                    this.SetAttributeValue("asyncautodelete", false);
                }
            }
        }

        /// <summary>
        /// Identifies whether a SDK Message Processing Step type will be ReadOnly or Read Write. false - ReadWrite, true - ReadOnly 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("canusereadonlyconnection")]
        public System.Nullable<bool> CanUseReadOnlyConnection
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("canusereadonlyconnection");
            }
            set
            {
                this.OnPropertyChanging("CanUseReadOnlyConnection");
                this.SetAttributeValue("canusereadonlyconnection", value);
                this.OnPropertyChanged("CanUseReadOnlyConnection");
            }
        }
        /// <summary>
        /// CanUseReadOnlyConnection as Enum
        /// </summary>
        public System.Nullable<Xrm.PluginDeployer.Entities.SdkMessageProcessingStep.OptionSet.IsOperationIntentReadOnly> CanUseReadOnlyConnectionAsEnum
        {
            get
            {
                if (!CanUseReadOnlyConnection.HasValue) return null;
                if (CanUseReadOnlyConnection.Value) return Xrm.PluginDeployer.Entities.SdkMessageProcessingStep.OptionSet.IsOperationIntentReadOnly.Yes;
                return Xrm.PluginDeployer.Entities.SdkMessageProcessingStep.OptionSet.IsOperationIntentReadOnly.No;
            }
            set
            {
                if (!value.HasValue) this.SetAttributeValue("canusereadonlyconnection", null);
                if (value.Value == Xrm.PluginDeployer.Entities.SdkMessageProcessingStep.OptionSet.IsOperationIntentReadOnly.Yes)
                {
                    this.SetAttributeValue("canusereadonlyconnection", true);
                }
                else
                {
                    this.SetAttributeValue("canusereadonlyconnection", false);
                }
            }
        }

        /// <summary>
        /// For internal use only.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("componentstate")]
        public Microsoft.Xrm.Sdk.OptionSetValue ComponentState
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("componentstate");
            }
        }

        /// <summary>
        /// Step-specific configuration for the plug-in type. Passed to the plug-in constructor at run time.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("configuration")]
        public string Configuration
        {
            get
            {
                return this.GetAttributeValue<string>("configuration");
            }
            set
            {
                this.OnPropertyChanging("Configuration");
                this.SetAttributeValue("configuration", value);
                this.OnPropertyChanged("Configuration");
            }
        }

        /// <summary>
        /// Unique identifier of the user who created the SDK message processing step.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdby")]
        public Microsoft.Xrm.Sdk.EntityReference CreatedBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdby");
            }
        }

        /// <summary>
        /// Date and time when the SDK message processing step was created.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdon")]
        public System.Nullable<System.DateTime> CreatedOn
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("createdon");
            }
        }

        /// <summary>
        /// Unique identifier of the delegate user who created the sdkmessageprocessingstep.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("createdonbehalfby")]
        public Microsoft.Xrm.Sdk.EntityReference CreatedOnBehalfBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("createdonbehalfby");
            }
        }

        /// <summary>
        /// Customization level of the SDK message processing step.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("customizationlevel")]
        public System.Nullable<int> CustomizationLevel
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("customizationlevel");
            }
        }

        /// <summary>
        /// Description of the SDK message processing step.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("description")]
        public string Description
        {
            get
            {
                return this.GetAttributeValue<string>("description");
            }
            set
            {
                this.OnPropertyChanging("Description");
                this.SetAttributeValue("description", value);
                this.OnPropertyChanged("Description");
            }
        }

        /// <summary>
        /// Unique identifier of the associated event handler.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("eventhandler")]
        public Microsoft.Xrm.Sdk.EntityReference EventHandler
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("eventhandler");
            }
            set
            {
                this.OnPropertyChanging("EventHandler");
                this.SetAttributeValue("eventhandler", value);
                this.OnPropertyChanged("EventHandler");
            }
        }

        /// <summary>
        /// Comma-separated list of attributes. If at least one of these attributes is modified, the plug-in should execute.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("filteringattributes")]
        public string FilteringAttributes
        {
            get
            {
                return this.GetAttributeValue<string>("filteringattributes");
            }
            set
            {
                this.OnPropertyChanging("FilteringAttributes");
                this.SetAttributeValue("filteringattributes", value);
                this.OnPropertyChanged("FilteringAttributes");
            }
        }

        /// <summary>
        /// Unique identifier of the user to impersonate context when step is executed.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("impersonatinguserid")]
        public Microsoft.Xrm.Sdk.EntityReference ImpersonatingUserId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("impersonatinguserid");
            }
            set
            {
                this.OnPropertyChanging("ImpersonatingUserId");
                this.SetAttributeValue("impersonatinguserid", value);
                this.OnPropertyChanged("ImpersonatingUserId");
            }
        }

        /// <summary>
        /// Version in which the form is introduced.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("introducedversion")]
        public string IntroducedVersion
        {
            get
            {
                return this.GetAttributeValue<string>("introducedversion");
            }
            set
            {
                this.OnPropertyChanging("IntroducedVersion");
                this.SetAttributeValue("introducedversion", value);
                this.OnPropertyChanged("IntroducedVersion");
            }
        }

        /// <summary>
        /// Identifies if a plug-in should be executed from a parent pipeline, a child pipeline, or both.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("invocationsource")]
        public Microsoft.Xrm.Sdk.OptionSetValue InvocationSource
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("invocationsource");
            }
            set
            {
                this.OnPropertyChanging("InvocationSource");
                this.SetAttributeValue("invocationsource", value);
                this.OnPropertyChanged("InvocationSource");
            }
        }

        /// <summary>
        /// Information that specifies whether this component can be customized.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("iscustomizable")]
        public Microsoft.Xrm.Sdk.BooleanManagedProperty IsCustomizable
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.BooleanManagedProperty>("iscustomizable");
            }
            set
            {
                this.OnPropertyChanging("IsCustomizable");
                this.SetAttributeValue("iscustomizable", value);
                this.OnPropertyChanged("IsCustomizable");
            }
        }

        /// <summary>
        /// Information that specifies whether this component should be hidden.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ishidden")]
        public Microsoft.Xrm.Sdk.BooleanManagedProperty IsHidden
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.BooleanManagedProperty>("ishidden");
            }
            set
            {
                this.OnPropertyChanging("IsHidden");
                this.SetAttributeValue("ishidden", value);
                this.OnPropertyChanged("IsHidden");
            }
        }

        /// <summary>
        /// Information that specifies whether this component is managed.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ismanaged")]
        public System.Nullable<bool> IsManaged
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("ismanaged");
            }
        }
        /// <summary>
        /// IsManaged as Enum
        /// </summary>
        public System.Nullable<Xrm.PluginDeployer.Entities.SdkMessageProcessingStep.OptionSet.IsComponentManaged> IsManagedAsEnum
        {
            get
            {
                if (!IsManaged.HasValue) return null;
                if (IsManaged.Value) return Xrm.PluginDeployer.Entities.SdkMessageProcessingStep.OptionSet.IsComponentManaged.Managed;
                return Xrm.PluginDeployer.Entities.SdkMessageProcessingStep.OptionSet.IsComponentManaged.Unmanaged;
            }
            set
            {
                if (!value.HasValue) this.SetAttributeValue("ismanaged", null);
                if (value.Value == Xrm.PluginDeployer.Entities.SdkMessageProcessingStep.OptionSet.IsComponentManaged.Managed)
                {
                    this.SetAttributeValue("ismanaged", true);
                }
                else
                {
                    this.SetAttributeValue("ismanaged", false);
                }
            }
        }

        /// <summary>
        /// Run-time mode of execution, for example, synchronous or asynchronous.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("mode")]
        public Microsoft.Xrm.Sdk.OptionSetValue Mode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("mode");
            }
            set
            {
                this.OnPropertyChanging("Mode");
                this.SetAttributeValue("mode", value);
                this.OnPropertyChanged("Mode");
            }
        }

        /// <summary>
        /// Unique identifier of the user who last modified the SDK message processing step.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedby")]
        public Microsoft.Xrm.Sdk.EntityReference ModifiedBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedby");
            }
        }

        /// <summary>
        /// Date and time when the SDK message processing step was last modified.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedon")]
        public System.Nullable<System.DateTime> ModifiedOn
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("modifiedon");
            }
        }

        /// <summary>
        /// Unique identifier of the delegate user who last modified the sdkmessageprocessingstep.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("modifiedonbehalfby")]
        public Microsoft.Xrm.Sdk.EntityReference ModifiedOnBehalfBy
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("modifiedonbehalfby");
            }
        }

        /// <summary>
        /// Name of SdkMessage processing step.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("name")]
        public string Name
        {
            get
            {
                return this.GetAttributeValue<string>("name");
            }
            set
            {
                this.OnPropertyChanging("Name");
                this.SetAttributeValue("name", value);
                this.OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Unique identifier of the organization with which the SDK message processing step is associated.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("organizationid")]
        public Microsoft.Xrm.Sdk.EntityReference OrganizationId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("organizationid");
            }
        }

        /// <summary>
        /// For internal use only.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("overwritetime")]
        public System.Nullable<System.DateTime> OverwriteTime
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("overwritetime");
            }
        }

        /// <summary>
        /// Unique identifier of the plug-in type associated with the step.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("plugintypeid")]
        public Microsoft.Xrm.Sdk.EntityReference PluginTypeId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("plugintypeid");
            }
            set
            {
                this.OnPropertyChanging("PluginTypeId");
                this.SetAttributeValue("plugintypeid", value);
                this.OnPropertyChanged("PluginTypeId");
            }
        }

        /// <summary>
        /// Processing order within the stage.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("rank")]
        public System.Nullable<int> Rank
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<int>>("rank");
            }
            set
            {
                this.OnPropertyChanging("Rank");
                this.SetAttributeValue("rank", value);
                this.OnPropertyChanged("Rank");
            }
        }

        /// <summary>
        /// Unique identifier of the SDK message filter.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessagefilterid")]
        public Microsoft.Xrm.Sdk.EntityReference SdkMessageFilterId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("sdkmessagefilterid");
            }
            set
            {
                this.OnPropertyChanging("SdkMessageFilterId");
                this.SetAttributeValue("sdkmessagefilterid", value);
                this.OnPropertyChanged("SdkMessageFilterId");
            }
        }

        /// <summary>
        /// Unique identifier of the SDK message.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageid")]
        public Microsoft.Xrm.Sdk.EntityReference SdkMessageId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("sdkmessageid");
            }
            set
            {
                this.OnPropertyChanging("SdkMessageId");
                this.SetAttributeValue("sdkmessageid", value);
                this.OnPropertyChanged("SdkMessageId");
            }
        }

        /// <summary>
        /// Unique identifier of the SDK message processing step entity.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageprocessingstepid")]
        public System.Nullable<System.Guid> SdkMessageProcessingStepId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("sdkmessageprocessingstepid");
            }
            set
            {
                this.OnPropertyChanging("SdkMessageProcessingStepId");
                this.SetAttributeValue("sdkmessageprocessingstepid", value);
                if (value.HasValue)
                {
                    base.Id = value.Value;
                }
                else
                {
                    base.Id = System.Guid.Empty;
                }
                this.OnPropertyChanged("SdkMessageProcessingStepId");
            }
        }

        /// <summary/>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageprocessingstepid")]
        public override System.Guid Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                this.SdkMessageProcessingStepId = value;
            }
        }

        /// <summary>
        /// Unique identifier of the SDK message processing step.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageprocessingstepidunique")]
        public System.Nullable<System.Guid> SdkMessageProcessingStepIdUnique
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("sdkmessageprocessingstepidunique");
            }
        }

        /// <summary>
        /// Unique identifier of the Sdk message processing step secure configuration.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("sdkmessageprocessingstepsecureconfigid")]
        public Microsoft.Xrm.Sdk.EntityReference SdkMessageProcessingStepSecureConfigId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("sdkmessageprocessingstepsecureconfigid");
            }
            set
            {
                this.OnPropertyChanging("SdkMessageProcessingStepSecureConfigId");
                this.SetAttributeValue("sdkmessageprocessingstepsecureconfigid", value);
                this.OnPropertyChanged("SdkMessageProcessingStepSecureConfigId");
            }
        }

        /// <summary>
        /// Unique identifier of the associated solution.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutionid")]
        public System.Nullable<System.Guid> SolutionId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("solutionid");
            }
        }

        /// <summary>
        /// Stage in the execution pipeline that the SDK message processing step is in.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("stage")]
        public Microsoft.Xrm.Sdk.OptionSetValue Stage
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("stage");
            }
            set
            {
                this.OnPropertyChanging("Stage");
                this.SetAttributeValue("stage", value);
                this.OnPropertyChanged("Stage");
            }
        }

        /// <summary>
        /// Status of the SDK message processing step.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statecode")]
        public System.Nullable<Xrm.PluginDeployer.Entities.SdkMessageProcessingStep.OptionSet.Status> StateCode
        {
            get
            {
                var optionSet = this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statecode");
                if (optionSet != null)
                {
                    return (Xrm.PluginDeployer.Entities.SdkMessageProcessingStep.OptionSet.Status)System.Enum.ToObject(typeof(Xrm.PluginDeployer.Entities.SdkMessageProcessingStep.OptionSet.Status),optionSet.Value);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.OnPropertyChanging("StateCode");
                if (value == null)
                {
                    this.SetAttributeValue("statecode", null);
                }
                else
                {
                    this.SetAttributeValue("statecode", new Microsoft.Xrm.Sdk.OptionSetValue((int)value));
                }
                this.OnPropertyChanged("StateCode");
            }
        }

        /// <summary>
        /// Reason for the status of the SDK message processing step.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("statuscode")]
        public Microsoft.Xrm.Sdk.OptionSetValue StatusCode
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("statuscode");
            }
            set
            {
                this.OnPropertyChanging("StatusCode");
                this.SetAttributeValue("statuscode", value);
                this.OnPropertyChanged("StatusCode");
            }
        }

        /// <summary>
        /// Deployment that the SDK message processing step should be executed on; server, client, or both.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("supporteddeployment")]
        public Microsoft.Xrm.Sdk.OptionSetValue SupportedDeployment
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("supporteddeployment");
            }
            set
            {
                this.OnPropertyChanging("SupportedDeployment");
                this.SetAttributeValue("supporteddeployment", value);
                this.OnPropertyChanged("SupportedDeployment");
            }
        }

        /// <summary>
        /// For internal use only.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("supportingsolutionid")]
        public System.Nullable<System.Guid> SupportingSolutionId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("supportingsolutionid");
            }
        }

        /// <summary>
        /// Number that identifies a specific revision of the SDK message processing step. 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("versionnumber")]
        public System.Nullable<long> VersionNumber
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<long>>("versionnumber");
            }
        }

        /// <summary/>
        public class OptionSet
        {

            /// <summary/>
            public enum Status
            {

                /// <summary/>
                Enabled = 0,

                /// <summary/>
                Disabled = 1,
            }

            /// <summary/>
            public enum IsOperationIntentReadOnly
            {

                /// <summary/>
                No = 0,

                /// <summary/>
                Yes = 1,
            }

            /// <summary/>
            public enum ComponentState
            {

                /// <summary/>
                Published = 0,

                /// <summary/>
                Unpublished = 1,

                /// <summary/>
                Deleted = 2,

                /// <summary/>
                DeletedUnpublished = 3,
            }

            /// <summary/>
            public enum Stage
            {

                /// <summary/>
                InitialPreOperationForInternalUseOnly = 5,

                /// <summary/>
                PreValidation = 10,

                /// <summary/>
                InternalPreOperationBeforeExternalPlugin = 15,

                /// <summary/>
                PreOperation = 20,

                /// <summary/>
                InternalPreOperationAfterExternalPlugins = 25,

                /// <summary/>
                MainOperationForInternalUseOnly = 30,

                /// <summary/>
                InternalPostOperationBeforeExternalPlugi = 35,

                /// <summary/>
                PostOperation = 40,

                /// <summary/>
                InternalPostOperationAfterExternalPlugin = 45,

                /// <summary/>
                PostOperationDeprecated = 50,

                /// <summary/>
                FinalPostOperationForInternalUseOnly = 55,
            }

            /// <summary/>
            public enum IsComponentManaged
            {

                /// <summary/>
                Unmanaged = 0,

                /// <summary/>
                Managed = 1,
            }

            /// <summary/>
            public enum InvocationSource
            {

                /// <summary/>
                Internal = -1,

                /// <summary/>
                Parent = 0,

                /// <summary/>
                Child = 1,
            }

            /// <summary/>
            public enum StatusReason
            {

                /// <summary/>
                Enabled = 1,

                /// <summary/>
                Disabled = 2,
            }

            /// <summary/>
            public enum SupportedDeployment
            {

                /// <summary/>
                ServerOnly = 0,

                /// <summary/>
                MicrosoftDynamics365ClientForOutlookOnly = 1,

                /// <summary/>
                Both = 2,
            }

            /// <summary/>
            public enum Mode
            {

                /// <summary/>
                Synchronous = 0,

                /// <summary/>
                Asynchronous = 1,
            }

            /// <summary/>
            public enum Sdkmessageprocessingstep_Asyncautodelete
            {

                /// <summary/>
                No = 0,

                /// <summary/>
                Yes = 1,
            }

        }

        /// <summary/>
        public class PropertyNames
        {

            /// <summary/>
            public const string AsyncAutoDelete = "asyncautodelete";

            /// <summary/>
            public const string AsyncAutoDeleteName = "asyncautodeletename";

            /// <summary/>
            public const string CanUseReadOnlyConnection = "canusereadonlyconnection";

            /// <summary/>
            public const string CanUseReadOnlyConnectionName = "canusereadonlyconnectionname";

            /// <summary/>
            public const string ComponentState = "componentstate";

            /// <summary/>
            public const string ComponentStateName = "componentstatename";

            /// <summary/>
            public const string Configuration = "configuration";

            /// <summary/>
            public const string CreatedBy = "createdby";

            /// <summary/>
            public const string CreatedByName = "createdbyname";

            /// <summary/>
            public const string CreatedOn = "createdon";

            /// <summary/>
            public const string CreatedOnBehalfBy = "createdonbehalfby";

            /// <summary/>
            public const string CreatedOnBehalfByName = "createdonbehalfbyname";

            /// <summary/>
            public const string CustomizationLevel = "customizationlevel";

            /// <summary/>
            public const string Description = "description";

            /// <summary/>
            public const string EventHandler = "eventhandler";

            /// <summary/>
            public const string EventHandlerName = "eventhandlername";

            /// <summary/>
            public const string FilteringAttributes = "filteringattributes";

            /// <summary/>
            public const string ImpersonatingUserId = "impersonatinguserid";

            /// <summary/>
            public const string ImpersonatingUserIdName = "impersonatinguseridname";

            /// <summary/>
            public const string IntroducedVersion = "introducedversion";

            /// <summary/>
            public const string InvocationSource = "invocationsource";

            /// <summary/>
            public const string InvocationSourceName = "invocationsourcename";

            /// <summary/>
            public const string IsCustomizable = "iscustomizable";

            /// <summary/>
            public const string IsHidden = "ishidden";

            /// <summary/>
            public const string IsManaged = "ismanaged";

            /// <summary/>
            public const string IsManagedName = "ismanagedname";

            /// <summary/>
            public const string Mode = "mode";

            /// <summary/>
            public const string ModeName = "modename";

            /// <summary/>
            public const string ModifiedBy = "modifiedby";

            /// <summary/>
            public const string ModifiedByName = "modifiedbyname";

            /// <summary/>
            public const string ModifiedOn = "modifiedon";

            /// <summary/>
            public const string ModifiedOnBehalfBy = "modifiedonbehalfby";

            /// <summary/>
            public const string ModifiedOnBehalfByName = "modifiedonbehalfbyname";

            /// <summary/>
            public const string Name = "name";

            /// <summary/>
            public const string OrganizationId = "organizationid";

            /// <summary/>
            public const string OrganizationIdName = "organizationidname";

            /// <summary/>
            public const string OverwriteTime = "overwritetime";

            /// <summary/>
            public const string PluginTypeId = "plugintypeid";

            /// <summary/>
            public const string PluginTypeIdName = "plugintypeidname";

            /// <summary/>
            public const string Rank = "rank";

            /// <summary/>
            public const string SdkMessageFilterId = "sdkmessagefilterid";

            /// <summary/>
            public const string SdkMessageFilterIdName = "sdkmessagefilteridname";

            /// <summary/>
            public const string SdkMessageId = "sdkmessageid";

            /// <summary/>
            public const string SdkMessageIdName = "sdkmessageidname";

            /// <summary/>
            public const string SdkMessageProcessingStepId = "sdkmessageprocessingstepid";

            /// <summary/>
            public const string SdkMessageProcessingStepIdUnique = "sdkmessageprocessingstepidunique";

            /// <summary/>
            public const string SdkMessageProcessingStepSecureConfigId = "sdkmessageprocessingstepsecureconfigid";

            /// <summary/>
            public const string SdkMessageProcessingStepSecureConfigIdName = "sdkmessageprocessingstepsecureconfigidname";

            /// <summary/>
            public const string SolutionId = "solutionid";

            /// <summary/>
            public const string Stage = "stage";

            /// <summary/>
            public const string StageName = "stagename";

            /// <summary/>
            public const string StateCode = "statecode";

            /// <summary/>
            public const string StateCodeName = "statecodename";

            /// <summary/>
            public const string StatusCode = "statuscode";

            /// <summary/>
            public const string StatusCodeName = "statuscodename";

            /// <summary/>
            public const string SupportedDeployment = "supporteddeployment";

            /// <summary/>
            public const string SupportedDeploymentName = "supporteddeploymentname";

            /// <summary/>
            public const string SupportingSolutionId = "supportingsolutionid";

            /// <summary/>
            public const string VersionNumber = "versionnumber";

        }

        /// <summary/>
        public class Ref
        {
        }
    }

    /// <summary>
    /// Represents a source of entities bound to a CRM service. It tracks and manages changes made to the retrieved entities.
    /// </summary>
    public partial class CrmContext : Microsoft.Xrm.Sdk.Client.OrganizationServiceContext
    {

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
    }
}
