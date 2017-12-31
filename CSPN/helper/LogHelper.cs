using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.helper
{
    public class LogHelper
    {
        static readonly ILog logerror = LogManager.GetLogger("loggError");
        static readonly ILog quartzLog = LogManager.GetLogger("QuartzLog");

        public static void WriteLog(string info)
        {
            if (logerror.IsErrorEnabled)
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
            if (quartzLog.IsErrorEnabled)
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
