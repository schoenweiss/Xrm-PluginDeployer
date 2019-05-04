using Microsoft.Xrm.Sdk;
using System;
using Xrm.PluginDeployer.Entities;

namespace Xrm.PluginDeployer.Utility
{
    public class CrmUnitOfWork: UnitOfWork, IDisposable
    {
        #region Members
        protected CrmContext context;
        public IOrganizationService Service { get; private set; }
        private IOrganizationServiceFactory ServiceFactory { get; set; }
        #endregion

        public CrmUnitOfWork(IOrganizationService service)
        {
            Service = service;
            this.context = new CrmContext(Service);
        }

        #region IDisposable

        public void Dispose()
        {
            context.Dispose();
        }

        #endregion

        #region IUnitOfWork

        #region generic methods
        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        /// <summary>
        /// Executes a CRM request.
        /// </summary>
        /// <typeparam name="R">Type of the response.</typeparam>
        /// <param name="request">Request to execute.</param>
        public T ExecuteRequest<T>(OrganizationRequest request) where T : OrganizationResponse
        {
            return (T) context.Execute(request);
        }

        public OrganizationResponse Execute(OrganizationRequest request)
        {
            return context.Execute(request);
        }

        public OrganizationResponse Execute(OrganizationRequest request, Guid runAsSystemUserID)
        {
            var ser = this.ServiceFactory.CreateOrganizationService(runAsSystemUserID);
            return ser.Execute(request);
        }

        public Guid Create(Microsoft.Xrm.Sdk.Entity entity)
        {
            return this.Service.Create(entity);
        }

        public void Update(Microsoft.Xrm.Sdk.Entity entity)
        {
            this.Service.Update(entity);
        }

        public void Delete(Microsoft.Xrm.Sdk.Entity entity)
        {
            this.Service.Delete(entity.LogicalName, entity.Id);
        }
        #endregion

        #region dynamic standard entities

        private Repository< Solution> _solutions;
        public Repository<Solution> Solutions
        {
            get
            {
                if (_solutions == null)
                {
                    _solutions = new CrmRepository<Solution>(this.context);
                }
                return _solutions;
            }
        }

        private Repository<SolutionComponent> _solutioncomponents;
        public Repository<SolutionComponent> SolutionComponents
        {
            get
            {
                if (_solutioncomponents == null)
                {
                    _solutioncomponents = new CrmRepository<SolutionComponent>(this.context);
                }
                return _solutioncomponents;
            }
        }

        private Repository<PluginAssembly> _pluginAssemblies;
        public Repository<PluginAssembly> PluginAssemblies
        {
            get
            {
                if (_pluginAssemblies == null)
                {
                    _pluginAssemblies = new CrmRepository<PluginAssembly>(this.context);
                }
                return _pluginAssemblies;
            }
        }

        private Repository<SdkMessageProcessingStep> _sdkMessageProcessingSteps;
        public Repository<SdkMessageProcessingStep> SdkMessageProcessingSteps
        {
            get
            {
                if (_sdkMessageProcessingSteps == null)
                {
                    _sdkMessageProcessingSteps = new CrmRepository<SdkMessageProcessingStep>(this.context);
                }
                return _sdkMessageProcessingSteps;
            }
        }

        private Repository<SdkMessageProcessingStepImage> _sdkMessageProcessingStepImages;
        public Repository<SdkMessageProcessingStepImage> SdkMessageProcessingStepImages
        {
            get
            {
                if (_sdkMessageProcessingStepImages == null)
                {
                    _sdkMessageProcessingStepImages = new CrmRepository<SdkMessageProcessingStepImage>(this.context);
                }
                return _sdkMessageProcessingStepImages;
            }
        }

        private Repository<PluginType> _plugintypes;
        public Repository<PluginType> PluginTypes
        {
            get
            {
                if (_plugintypes == null)
                {
                    _plugintypes = new CrmRepository<PluginType>(this.context);
                }
                return _plugintypes;
            }
        }

        private Repository<SdkMessage> _sdkMessages;
        public Repository<SdkMessage> SdkMessages
        {
            get
            {
                if (_sdkMessages == null)
                {
                    _sdkMessages = new CrmRepository<SdkMessage>(this.context);
                }
                return _sdkMessages;
            }
        }

        private Repository<SdkMessageFilter> _sdkMessageFilters;
        public Repository<SdkMessageFilter> SdkMessageFilters
        {
            get
            {
                if (_sdkMessageFilters == null)
                {
                    this._sdkMessageFilters = new CrmRepository<SdkMessageFilter>(this.context);
                }
                return _sdkMessageFilters;
            }
        }
        #endregion

        public void ClearChanges()
        {
            this.context.ClearChanges();
        }
        #endregion
    }
}
