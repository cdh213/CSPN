using CSPN.BLL;
using CSPN.common;
using CSPN.helper;
using CSPN.IBLL;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.job
{
    public class DeleteSysLogJob : IJob
    {
        ILogService logService = new LogService();
        public void Execute(IJobExecutionContext context)
        {
            int save_Day = int.Parse(ReadWriteConfig.ReadConfig("SysLogTime"));
            logService.DeleteSystemLogInfo(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), save_Day);
            LogHelper.WriteQuartzLog("删除超过" + save_Day + "天的系统日志");
        }
    }
}
