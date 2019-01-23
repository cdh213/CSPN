using CSPN.BLL;
using CSPN.IBLL;
using CSPN.Model;
using Quartz;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSPN.job
{
    public delegate void AutoSendSMSDelegate(List<WellCurrentStateInfo> wcsList);

    public class AutoSendSMSJob : IJob
    {
        public static event AutoSendSMSDelegate autoSendSMSEvent;

        private IWellStateService wellStateService = new WellStateService();
        private List<WellCurrentStateInfo> list = new List<WellCurrentStateInfo>();

        Task IJob.Execute(IJobExecutionContext context)
        {
            list = wellStateService.GetAlarmInfoList();

            if (list.Count != 0)
            {
                if (autoSendSMSEvent != null)
                {
                    autoSendSMSEvent(list);
                }
            }
            return Task.FromResult(true);
        }
    }
}