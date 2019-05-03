using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System.Configuration;

namespace Xrm.PluginDeployer.Utility.Tooling
{
    /// <summary>
    /// Connect to CRM via different factory methods
    /// </summary>
    public static class OrganizationServiceFactory
    {
        /// <summary>
        /// Connect to CRM with default config name 'CRM'
        /// </summary>
        public static IOrganizationService ConnectByConfig()
        {
            return ConnectByConfig("CRM");
        }

        /// <summary>
        /// Connect to CRM with connection string in config
        /// </summary>
        /// <param name="connectionStringName">Configname of connection string</param>
        public static IOrganizationService ConnectByConfig(string connectionStringName)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            return ConnectByConnectionString(connectionString);
        }

        /// <summary>
        /// Connect to CRM with given connection string
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        public static IOrganizationService ConnectByConnectionString(string connectionString)
        {
            var conn = new CrmServiceClient(connectionString);

            if (!conn.IsReady)
            {
                throw new Exception($"Error during establishing of CRM connection: {conn.LastCrmError}");
            }
            conn.OrganizationServiceProxy.Timeout = new TimeSpan(0, 10, 0); // default 2 minutes
            return conn.OrganizationWebProxyClient != null
                ? (IOrganizationService)conn.OrganizationWebProxyClient
                : conn.OrganizationServiceProxy;
        }
    }
}
