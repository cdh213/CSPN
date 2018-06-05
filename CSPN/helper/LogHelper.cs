using log4net;
using System;

namespace CSPN.helper
{
    public class LogHelper
    {
        private static readonly ILog logerror = LogManager.GetLogger("ApplicationLog");
        private static readonly ILog quartzLog = LogManager.GetLogger("QuartzLog");

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

        public static void WriteQuartzLog(string info)
        {
            if (quartzLog.IsInfoEnabled)
            {
                quartzLog.Info(info);
            }
        }

        public static void WriteQuartzLog(string info, Exception ex)
        {
            if (quartzLog.IsErrorEnabled)
            {
                quartzLog.Error(info, ex);
            }
        }
    }
}