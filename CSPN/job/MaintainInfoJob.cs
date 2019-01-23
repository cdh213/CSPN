using CSPN.BLL;
using CSPN.IBLL;
using CSPN.Model;
using Quartz;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSPN.job
{
    public class MaintainInfoJob : IJob
    {
        private IWellStateService wellStateService = new WellStateService();
        private List<WellMaintainInfo> startList = new List<WellMaintainInfo>();
        private List<WellMaintainInfo> endList = new List<WellMaintainInfo>();
        private string currentTime;

        Task IJob.Execute(IJobExecutionContext context)
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
                        wellStateService.MaintainInfoSet(startList[i].Terminal_ID);
                    }
                }
            }
            if (endList.Count != 0)
            {
                for (int i = 0; i < endList.Count; i++)
                {
                    wellStateService.MaintainInfoCancel(endList[i].Terminal_ID);
                }
            }
            return Task.FromResult(true);
        }
    }
}