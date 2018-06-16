using log4net;
using Quartz.Logging;
using System;

namespace CSPN.helper
{
    public class LogHelper : ILogProvider
    {
        private static readonly ILog logerror = LogManager.GetLogger("ApplicationLog");

        public static void WriteLog(string info)
        {
            if (logerror.IsInfoEnabled)
            {
                logerror.Info(info);
            }
        }

        public static void WriteLog(string info, Exception ex)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(info, ex);
            }
        }

        public Logger GetLogger(string name)
        {
            return (level, func, exception, parameters) =>
            {
                if (level >= LogLevel.Info && func != null)
                {
                    if (logerror.IsInfoEnabled)
                    {
                        logerror.InfoFormat("[" + DateTime.Now.ToLongTimeString() + "] [" + level + "] " + func(), parameters);
                    }
                }
                return true;
            };
        }

        public IDisposable OpenMappedContext(string key, string value)
        {
            throw new NotImplementedException();
        }

        public IDisposable OpenNestedContext(string message)
        {
            throw new NotImplementedException();
        }
    }
}