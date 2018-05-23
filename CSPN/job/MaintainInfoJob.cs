using CSPN.BLL;
using CSPN.helper;
using CSPN.IBLL;
using CSPN.Model;
using Quartz;
using System;
using System.Collections.Generic;

namespace CSPN.job
{
    public class MaintainInfoJob : IJob
    {
        private IWellStateService wellStateService = new WellStateService();
        private string currentTime;
        private List<WellMaintainInfo> startList = new List<WellMaintainInfo>();
        private List<WellMaintainInfo> endList = new List<WellMaintainInfo>();

        public void Execute(IJobExecutionContext context)
        {
            currentTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:00");
            startList = wellStateService.GetMaintain_StartTime(currentTime);
            endList = wellStateService.GetMaintain_EndTime(currentTime);
            if (startList.Count != 0)
            {
                for (int i = 0; i < startList.Count; i++)
                {
                    if (startList[i].Maintain_State == 0)
                    {
                        wellStateService.UpdateMaintainInfo(1, startList[i].Terminal_ID);
                        wellStateService.UpdateWellCurrentStateInfo(6, startList[i].Terminal_ID);
                        LogHelper.WriteQuartzLog($"设置人井：{startList[i].Terminal_ID}为维护状态。");
                    }
                }
            }
            if (endList.Count != 0)
            {
                for (int i = 0; i < endList.Count; i++)
                {
                    wellStateService.UpdateWellCurrentStateInfo(1, endList[i].Terminal_ID);
                    LogHelper.WriteQuartzLog($"人井：{endList[i].Terminal_ID}由维护状态设置为正常。");
                }
            }
        }
    }
}