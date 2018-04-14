using CSPN.BLL;
using CSPN.common;
using CSPN.helper;
using CSPN.IBLL;
using Quartz;
using System;

namespace CSPN.job
{
    public class DeleteLogJob : IJob
    {
        ILogService logService = new LogService();
        int sysSave_Day, userSave_Day;

        public void Execute(IJobExecutionContext context)
        {
            sysSave_Day = int.Parse(ReadWriteXml.ReadXml("SysLogTime"));
            if (logService.DeleteSystemLogInfo(DateTime.Now.ToString("yyyy/MM/dd"), sysSave_Day) > 0)
            {
                LogHelper.WriteQuartzLog("删除超过" + sysSave_Day + "天的系统日志");
            }

            userSave_Day = int.Parse(ReadWriteXml.ReadXml("UserLogTime"));
            if (logService.DeleteUserLogInfo(DateTime.Now.ToString("yyyy/MM/dd"), userSave_Day) > 0)
            {
                LogHelper.WriteQuartzLog("删除超过" + userSave_Day + "天的用户日志");
            }
        }
    }
}
