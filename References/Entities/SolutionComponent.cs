//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Xrm.PluginDeployer.Entities
{
    /// <summary>
    /// A component of a CRM solution.
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute()]
    [Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("solutioncomponent")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xrm.PluginDeployer.DevTool.BackEndEarlyBind", "1.0")]
    public partial class SolutionComponent : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public SolutionComponent() : 
                base(EntityLogicalName)
        {
        }

        /// <summary/>
        public const string EntityLogicalName = "solutioncomponent";
        
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
        /// The object type code of the component.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("componenttype")]
        public Microsoft.Xrm.Sdk.OptionSetValue ComponentType
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("componenttype");
            }
        }

        /// <summary>
        /// Unique identifier of the user who created the solution
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
        /// Date and time when the solution was created.
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
        /// Unique identifier of the delegate user who created the solution.
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
        /// Indicates whether this component is metadata or data.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("ismetadata")]
        public System.Nullable<bool> IsMetadata
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("ismetadata");
            }
        }
        /// <summary>
        /// IsMetadata as Enum
        /// </summary>
        public System.Nullable<Xrm.PluginDeployer.Entities.SolutionComponent.OptionSet.IsThisComponentMetadata> IsMetadataAsEnum
        {
            get
            {
                if (!IsMetadata.HasValue) return null;
                if (IsMetadata.Value) return Xrm.PluginDeployer.Entities.SolutionComponent.OptionSet.IsThisComponentMetadata.Metadata;
                return Xrm.PluginDeployer.Entities.SolutionComponent.OptionSet.IsThisComponentMetadata.Data;
            }
            set
            {
                if (!value.HasValue) this.SetAttributeValue("ismetadata", null);
                if (value.Value == Xrm.PluginDeployer.Entities.SolutionComponent.OptionSet.IsThisComponentMetadata.Metadata)
                {
                    this.SetAttributeValue("ismetadata", true);
                }
                else
                {
                    this.SetAttributeValue("ismetadata", false);
                }
            }
        }

        /// <summary>
        /// Unique identifier of the user who last modified the solution.
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
        /// Date and time when the solution was last modified.
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
        /// Unique identifier of the delegate user who modified the solution.
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
        /// Unique identifier of the object with which the component is associated.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("objectid")]
        public System.Nullable<System.Guid> ObjectId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("objectid");
            }
        }

        /// <summary>
        /// Indicates the include behavior of the root component.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("rootcomponentbehavior")]
        public Microsoft.Xrm.Sdk.OptionSetValue RootComponentBehavior
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("rootcomponentbehavior");
            }
        }

        /// <summary>
        /// The parent ID of the subcomponent, which will be a root
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("rootsolutioncomponentid")]
        public System.Nullable<System.Guid> RootSolutionComponentId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("rootsolutioncomponentid");
            }
        }

        /// <summary>
        /// Unique identifier of the solution component.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutioncomponentid")]
        public System.Nullable<System.Guid> SolutionComponentId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("solutioncomponentid");
            }
            set
            {
                this.OnPropertyChanging("SolutionComponentId");
                this.SetAttributeValue("solutioncomponentid", value);
                if (value.HasValue)
                {
                    base.Id = value.Value;
                }
                else
                {
                    base.Id = System.Guid.Empty;
                }
                this.OnPropertyChanged("SolutionComponentId");
            }
        }

        /// <summary/>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutioncomponentid")]
        public override System.Guid Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                this.SolutionComponentId = value;
            }
        }

        /// <summary>
        /// Unique identifier of the solution.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutionid")]
        public Microsoft.Xrm.Sdk.EntityReference SolutionId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("solutionid");
            }
        }

        /// <summary>
        /// 
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
            public enum IncludeBehavior
            {

                /// <summary/>
                IncludeSubcomponents = 0,

                /// <summary/>
                DoNotIncludeSubcomponents = 1,

                /// <summary/>
                IncludeAsShellOnly = 2,
            }

            /// <summary/>
            public enum IsThisComponentMetadata
            {

                /// <summary/>
                Data = 0,

                /// <summary/>
                Metadata = 1,
            }

            /// <summary/>
            public enum ComponentType
            {

                /// <summary/>
                Entity = 1,

                /// <summary/>
                Attribute = 2,

                /// <summary/>
                Relationship = 3,

                /// <summary/>
                AttributePicklistValue = 4,

                /// <summary/>
                AttributeLookupValue = 5,

                /// <summary/>
                ViewAttribute = 6,

                /// <summary/>
                LocalizedLabel = 7,

                /// <summary/>
                RelationshipExtraCondition = 8,

                /// <summary/>
                OptionSet = 9,

                /// <summary/>
                EntityRelationship = 10,

                /// <summary/>
                EntityRelationshipRole = 11,

                /// <summary/>
                EntityRelationshipRelationships = 12,

                /// <summary/>
                ManagedProperty = 13,

                /// <summary/>
                EntityKey = 14,

                /// <summary/>
                Role = 20,

                /// <summary/>
                RolePrivilege = 21,

                /// <summary/>
                DisplayString = 22,

                /// <summary/>
                DisplayStringMap = 23,

                /// <summary/>
                Form = 24,

                /// <summary/>
                Organization = 25,

                /// <summary/>
                SavedQuery = 26,

                /// <summary/>
                Workflow = 29,

                /// <summary/>
                Report = 31,

                /// <summary/>
                ReportEntity = 32,

                /// <summary/>
                ReportCategory = 33,

                /// <summary/>
                ReportVisibility = 34,

                /// <summary/>
                Attachment = 35,

                /// <summary/>
                EmailTemplate = 36,

                /// <summary/>
                ContractTemplate = 37,

                /// <summary/>
                KbArticleTemplate = 38,

                /// <summary/>
                MailMergeTemplate = 39,

                /// <summary/>
                DuplicateRule = 44,

                /// <summary/>
                DuplicateRuleCondition = 45,

                /// <summary/>
                EntityMap = 46,

                /// <summary/>
                AttributeMap = 47,

                /// <summary/>
                RibbonCommand = 48,

                /// <summary/>
                RibbonContextGroup = 49,

                /// <summary/>
                RibbonCustomization = 50,

                /// <summary/>
                RibbonRule = 52,

                /// <summary/>
                RibbonTabToCommandMap = 53,

                /// <summary/>
                RibbonDiff = 55,

                /// <summary/>
                SavedQueryVisualization = 59,

                /// <summary/>
                SystemForm = 60,

                /// <summary/>
                WebResource = 61,

                /// <summary/>
                SiteMap = 62,

                /// <summary/>
                ConnectionRole = 63,

                /// <summary/>
                FieldSecurityProfile = 70,

                /// <summary/>
                FieldPermission = 71,

                /// <summary/>
                PluginType = 90,

                /// <summary/>
                PluginAssembly = 91,

                /// <summary/>
                SdkMessageProcessingStep = 92,

                /// <summary/>
                SdkMessageProcessingStepImage = 93,

                /// <summary/>
                ServiceEndpoint = 95,

                /// <summary/>
                RoutingRule = 150,

                /// <summary/>
                RoutingRuleItem = 151,

                /// <summary/>
                Sla = 152,

                /// <summary/>
                SlaItem = 153,

                /// <summary/>
                ConvertRule = 154,

                /// <summary/>
                ConvertRuleItem = 155,

                /// <summary/>
                HierarchyRule = 65,

                /// <summary/>
                MobileOfflineProfile = 161,

                /// <summary/>
                MobileOfflineProfileItem = 162,

                /// <summary/>
                SimilarityRule = 165,

                /// <summary/>
                CustomControl = 66,

                /// <summary/>
                CustomControlDefaultConfig = 68,
            }

        }

        /// <summary/>
        public class PropertyNames
        {

            /// <summary/>
            public const string ComponentType = "componenttype";

            /// <summary/>
            public const string ComponentTypeName = "componenttypename";

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
            public const string IsMetadata = "ismetadata";

            /// <summary/>
            public const string IsMetadataName = "ismetadataname";

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
            public const string ObjectId = "objectid";

            /// <summary/>
            public const string RootComponentBehavior = "rootcomponentbehavior";

            /// <summary/>
            public const string RootComponentBehaviorName = "rootcomponentbehaviorname";

            /// <summary/>
            public const string RootSolutionComponentId = "rootsolutioncomponentid";

            /// <summary/>
            public const string SolutionComponentId = "solutioncomponentid";

            /// <summary/>
            public const string SolutionId = "solutionid";

            /// <summary/>
            public const string SolutionIdName = "solutionidname";

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
