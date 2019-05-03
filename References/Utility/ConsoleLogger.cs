using System;
using log4net;
using log4net.Config;
using Microsoft.Xrm.Sdk;

namespace Xrm.PluginDeployer.Utility.Tooling
{
    public class ConsoleLogger : ITracingService
    {
        private ILog _err;
        private ILog _log;

        public ConsoleLogger(Type type)
        {
            _err = LogManager.GetLogger( "root" ); // error
            _log = LogManager.GetLogger(type);

            XmlConfigurator.Configure();
        }

        public void Trace(string format, params object[] args)
        {
            Log(format, args);
        }

        public void Log(string format, params object[] args)
        {
            _log.InfoFormat(format, args);
        }

        public void Error(string format, params object[] args)
        {
            _err.ErrorFormat(format, args);
        }
    }
}
