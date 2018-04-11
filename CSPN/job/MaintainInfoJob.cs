using CSPN.BLL;
using CSPN.helper;
using CSPN.IBLL;
using Quartz;
using System;

namespace CSPN.job
{
    public class MaintainInfoJob : IJob
    {
        IWellStateService wellStateService = new WellStateService();
        string nowTime;
        object terminal_ID_St, terminal_ID_End;

        public void Execute(IJobExecutionContext context)
        {
            nowTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:00");
            terminal_ID_St = wellStateService.GetMaintain_StartTime(nowTime);
            terminal_ID_End = wellStateService.GetMaintain_EndTime(nowTime);
            if (terminal_ID_St != null)
            {
                wellStateService.UpdateWellCurrentStateInfo(6, terminal_ID_St.ToString());
                LogHelper.WriteQuartzLog("设置人井：" + terminal_ID_St + "为维护状态。");
            }
            if (terminal_ID_End != null)
            {
                wellStateService.UpdateWellCurrentStateInfo(1, terminal_ID_End.ToString());
                LogHelper.WriteQuartzLog("人井：" + terminal_ID_St + "由维护状态设置为正常。");
            }
        }
    }
}
