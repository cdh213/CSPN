using CSPN.BLL;
using CSPN.IBLL;
using CSPN.Model;
using Quartz;
using System.Collections.Generic;

namespace CSPN.job
{
    public delegate void AutoSendSMSDelegate(List<WellCurrentStateInfo> wcsList);

    public class AutoSendSMSJob : IJob
    {
        public static AutoSendSMSDelegate autoSendSMSDelegate;
        private IWellStateService wellStateService = new WellStateService();
        private List<WellCurrentStateInfo> list = new List<WellCurrentStateInfo>();

        public void Execute(IJobExecutionContext context)
        {
            list = wellStateService.GetAlarmInfoList();

            if (list.Count != 0)
            {
                if (autoSendSMSDelegate != null)
                {
                    autoSendSMSDelegate(list);
                }
            }
        }
    }
}