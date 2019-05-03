using Microsoft.Xrm.Sdk;
using Xrm.PluginDeployer.Entities;
using System;

namespace Xrm.PluginDeployer.EntityExtensions
{
    public interface UnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits the applied changes.
        /// </summary>


        void SaveChanges();

        #region Dynamic standard entities
        Repository<Solution> Solutions { get; }
        Repository<SolutionComponent> SolutionComponents { get; }
        Repository<SdkMessage> SdkMessages { get; }
        Repository<SdkMessageFilter> SdkMessageFilters { get; }
        Repository<PluginAssembly> PluginAssemblies { get; }
        Repository<PluginType> PluginTypes { get; }
        Repository<SdkMessageProcessingStep> SdkMessageProcessingSteps { get; }
        Repository<SdkMessageProcessingStepImage> SdkMessageProcessingStepImages { get; }
        #endregion

        /// <summary>
        /// Executes a CRM request.
        /// </summary>
        /// <typeparam name="R">Type of the response.</typeparam>
        /// <param name="request">Request to execute.</param>
        R ExecuteRequest<R>(OrganizationRequest request) where R : OrganizationResponse;

        OrganizationResponse Execute(OrganizationRequest request);
        OrganizationResponse Execute(OrganizationRequest request, Guid runAsSystemUserID);

        Guid Create(Entity entity);
        void Update(Entity entity);
        void Delete(Entity entity);

        void ClearChanges();
    }
}
