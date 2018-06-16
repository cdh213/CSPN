using CSPN.BLL;
using CSPN.common;
using CSPN.IBLL;
using Quartz;
using System;
using System.Threading.Tasks;

namespace CSPN.job
{
    public class DeleteLogJob : IJob
    {
        private ILogService logService = new LogService();
        private int sysSave_Day, userSave_Day;

        Task IJob.Execute(IJobExecutionContext context)
        {
            sysSave_Day = int.Parse(ReadWriteXml.ReadXml("SysLogTime"));
            logService.DeleteSystemLogInfo(DateTime.Now.ToString("yyyy/MM/dd"), sysSave_Day);

            userSave_Day = int.Parse(ReadWriteXml.ReadXml("UserLogTime"));
            logService.DeleteUserLogInfo(DateTime.Now.ToString("yyyy/MM/dd"), userSave_Day);

            return Task.FromResult(true);
        }
    }
}