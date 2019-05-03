//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Xrm.PluginDeployer.Entities
{
    /// <summary>
    /// A solution which contains CRM customizations.
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute()]
    [Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("solution")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xrm.PluginDeployer.DevTool.BackEndEarlyBind", "1.0")]
    public partial class Solution : Microsoft.Xrm.Sdk.Entity, System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
    {

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Solution() : 
                base(EntityLogicalName)
        {
        }

        /// <summary/>
        public const string EntityLogicalName = "solution";
        
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
        /// A link to an optional configuration page for this solution.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("configurationpageid")]
        public Microsoft.Xrm.Sdk.EntityReference ConfigurationPageId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("configurationpageid");
            }
            set
            {
                this.OnPropertyChanging("ConfigurationPageId");
                this.SetAttributeValue("configurationpageid", value);
                this.OnPropertyChanged("ConfigurationPageId");
            }
        }

        /// <summary>
        /// Unique identifier of the user who created the solution.
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
        /// Description of the solution.
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
        /// User display name for the solution.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("friendlyname")]
        public string FriendlyName
        {
            get
            {
                return this.GetAttributeValue<string>("friendlyname");
            }
            set
            {
                this.OnPropertyChanging("FriendlyName");
                this.SetAttributeValue("friendlyname", value);
                this.OnPropertyChanged("FriendlyName");
            }
        }

        /// <summary>
        /// Date and time when the solution was installed/upgraded.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("installedon")]
        public System.Nullable<System.DateTime> InstalledOn
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.DateTime>>("installedon");
            }
        }

        /// <summary>
        /// Indicates whether the solution is internal or not.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isinternal")]
        public System.Nullable<bool> IsInternal
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("isinternal");
            }
        }
        /// <summary>
        /// IsInternal as Enum
        /// </summary>
        public System.Nullable<Xrm.PluginDeployer.Entities.Solution.OptionSet.IsInternalSolution> IsInternalAsEnum
        {
            get
            {
                if (!IsInternal.HasValue) return null;
                if (IsInternal.Value) return Xrm.PluginDeployer.Entities.Solution.OptionSet.IsInternalSolution.Yes;
                return Xrm.PluginDeployer.Entities.Solution.OptionSet.IsInternalSolution.No;
            }
            set
            {
                if (!value.HasValue) this.SetAttributeValue("isinternal", null);
                if (value.Value == Xrm.PluginDeployer.Entities.Solution.OptionSet.IsInternalSolution.Yes)
                {
                    this.SetAttributeValue("isinternal", true);
                }
                else
                {
                    this.SetAttributeValue("isinternal", false);
                }
            }
        }

        /// <summary>
        /// Indicates whether the solution is managed or unmanaged.
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
        public System.Nullable<Xrm.PluginDeployer.Entities.Solution.OptionSet.Managed> IsManagedAsEnum
        {
            get
            {
                if (!IsManaged.HasValue) return null;
                if (IsManaged.Value) return Xrm.PluginDeployer.Entities.Solution.OptionSet.Managed.Managed;
                return Xrm.PluginDeployer.Entities.Solution.OptionSet.Managed.Unmanaged;
            }
            set
            {
                if (!value.HasValue) this.SetAttributeValue("ismanaged", null);
                if (value.Value == Xrm.PluginDeployer.Entities.Solution.OptionSet.Managed.Managed)
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
        /// Indicates whether the solution is visible outside of the platform.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("isvisible")]
        public System.Nullable<bool> IsVisible
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<bool>>("isvisible");
            }
        }
        /// <summary>
        /// IsVisible as Enum
        /// </summary>
        public System.Nullable<Xrm.PluginDeployer.Entities.Solution.OptionSet.IsVisibleOutsidePlatform> IsVisibleAsEnum
        {
            get
            {
                if (!IsVisible.HasValue) return null;
                if (IsVisible.Value) return Xrm.PluginDeployer.Entities.Solution.OptionSet.IsVisibleOutsidePlatform.Yes;
                return Xrm.PluginDeployer.Entities.Solution.OptionSet.IsVisibleOutsidePlatform.No;
            }
            set
            {
                if (!value.HasValue) this.SetAttributeValue("isvisible", null);
                if (value.Value == Xrm.PluginDeployer.Entities.Solution.OptionSet.IsVisibleOutsidePlatform.Yes)
                {
                    this.SetAttributeValue("isvisible", true);
                }
                else
                {
                    this.SetAttributeValue("isvisible", false);
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
        /// Unique identifier of the organization associated with the solution.
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
        /// Unique identifier of the parent solution. Should only be non-null if this solution is a patch.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("parentsolutionid")]
        public Microsoft.Xrm.Sdk.EntityReference ParentSolutionId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("parentsolutionid");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("pinpointassetid")]
        public string PinpointAssetId
        {
            get
            {
                return this.GetAttributeValue<string>("pinpointassetid");
            }
        }

        /// <summary>
        /// Identifier of the publisher of this solution in Microsoft Pinpoint.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("pinpointpublisherid")]
        public System.Nullable<long> PinpointPublisherId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<long>>("pinpointpublisherid");
            }
        }

        /// <summary>
        /// Default locale of the solution in Microsoft Pinpoint.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("pinpointsolutiondefaultlocale")]
        public string PinpointSolutionDefaultLocale
        {
            get
            {
                return this.GetAttributeValue<string>("pinpointsolutiondefaultlocale");
            }
        }

        /// <summary>
        /// Identifier of the solution in Microsoft Pinpoint.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("pinpointsolutionid")]
        public System.Nullable<long> PinpointSolutionId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<long>>("pinpointsolutionid");
            }
        }

        /// <summary>
        /// Unique identifier of the publisher.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("publisherid")]
        public Microsoft.Xrm.Sdk.EntityReference PublisherId
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.EntityReference>("publisherid");
            }
            set
            {
                this.OnPropertyChanging("PublisherId");
                this.SetAttributeValue("publisherid", value);
                this.OnPropertyChanged("PublisherId");
            }
        }

        /// <summary>
        /// Unique identifier of the solution.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutionid")]
        public System.Nullable<System.Guid> SolutionId
        {
            get
            {
                return this.GetAttributeValue<System.Nullable<System.Guid>>("solutionid");
            }
            set
            {
                this.OnPropertyChanging("SolutionId");
                this.SetAttributeValue("solutionid", value);
                if (value.HasValue)
                {
                    base.Id = value.Value;
                }
                else
                {
                    base.Id = System.Guid.Empty;
                }
                this.OnPropertyChanged("SolutionId");
            }
        }

        /// <summary/>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutionid")]
        public override System.Guid Id
        {
            get
            {
                return base.Id;
            }
            set
            {
                this.SolutionId = value;
            }
        }

        /// <summary>
        /// Solution package source organization version
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutionpackageversion")]
        public string SolutionPackageVersion
        {
            get
            {
                return this.GetAttributeValue<string>("solutionpackageversion");
            }
            set
            {
                this.OnPropertyChanging("SolutionPackageVersion");
                this.SetAttributeValue("solutionpackageversion", value);
                this.OnPropertyChanged("SolutionPackageVersion");
            }
        }

        /// <summary>
        /// Solution Type
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("solutiontype")]
        public Microsoft.Xrm.Sdk.OptionSetValue SolutionType
        {
            get
            {
                return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("solutiontype");
            }
            set
            {
                this.OnPropertyChanging("SolutionType");
                this.SetAttributeValue("solutiontype", value);
                this.OnPropertyChanged("SolutionType");
            }
        }

        /// <summary>
        /// The unique name of this solution
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("uniquename")]
        public string UniqueName
        {
            get
            {
                return this.GetAttributeValue<string>("uniquename");
            }
            set
            {
                this.OnPropertyChanging("UniqueName");
                this.SetAttributeValue("uniquename", value);
                this.OnPropertyChanged("UniqueName");
            }
        }

        /// <summary>
        /// Solution version, used to identify a solution for upgrades and hotfixes.
        /// </summary>
        [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("version")]
        public string Version
        {
            get
            {
                return this.GetAttributeValue<string>("version");
            }
            set
            {
                this.OnPropertyChanging("Version");
                this.SetAttributeValue("version", value);
                this.OnPropertyChanged("Version");
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
            public enum IsVisibleOutsidePlatform
            {

                /// <summary/>
                No = 0,

                /// <summary/>
                Yes = 1,
            }

            /// <summary/>
            public enum IsInternalSolution
            {

                /// <summary/>
                No = 0,

                /// <summary/>
                Yes = 1,
            }

            /// <summary/>
            public enum Solution_Solutiontype
            {

                /// <summary/>
                None = 0,

                /// <summary/>
                Snapshot = 1,

                /// <summary/>
                Internal = 2,
            }

            /// <summary/>
            public enum Managed
            {

                /// <summary/>
                Unmanaged = 0,

                /// <summary/>
                Managed = 1,
            }

        }

        /// <summary/>
        public class PropertyNames
        {

            /// <summary/>
            public const string ConfigurationPageId = "configurationpageid";

            /// <summary/>
            public const string ConfigurationPageIdName = "configurationpageidname";

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
            public const string Description = "description";

            /// <summary/>
            public const string FriendlyName = "friendlyname";

            /// <summary/>
            public const string InstalledOn = "installedon";

            /// <summary/>
            public const string IsInternal = "isinternal";

            /// <summary/>
            public const string IsInternalName = "isinternalname";

            /// <summary/>
            public const string IsManaged = "ismanaged";

            /// <summary/>
            public const string IsManagedName = "ismanagedname";

            /// <summary/>
            public const string IsVisible = "isvisible";

            /// <summary/>
            public const string IsVisibleName = "isvisiblename";

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
            public const string OrganizationId = "organizationid";

            /// <summary/>
            public const string OrganizationIdName = "organizationidname";

            /// <summary/>
            public const string ParentSolutionId = "parentsolutionid";

            /// <summary/>
            public const string ParentSolutionIdName = "parentsolutionidname";

            /// <summary/>
            public const string PinpointAssetId = "pinpointassetid";

            /// <summary/>
            public const string PinpointPublisherId = "pinpointpublisherid";

            /// <summary/>
            public const string PinpointSolutionDefaultLocale = "pinpointsolutiondefaultlocale";

            /// <summary/>
            public const string PinpointSolutionId = "pinpointsolutionid";

            /// <summary/>
            public const string PublisherId = "publisherid";

            /// <summary/>
            public const string PublisherIdName = "publisheridname";

            /// <summary/>
            public const string SolutionId = "solutionid";

            /// <summary/>
            public const string SolutionPackageVersion = "solutionpackageversion";

            /// <summary/>
            public const string SolutionType = "solutiontype";

            /// <summary/>
            public const string SolutionTypeName = "solutiontypename";

            /// <summary/>
            public const string UniqueName = "uniquename";

            /// <summary/>
            public const string Version = "version";

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
        /// Gets a binding to the set of all <see cref="Xrm.PluginDeployer.Entities.Solution"/> entities.
        /// </summary>
        public System.Linq.IQueryable<Xrm.PluginDeployer.Entities.Solution> SolutionSet
        {
            get
            {
                return this.CreateQuery<Xrm.PluginDeployer.Entities.Solution>();
            }
        }
    }
}
