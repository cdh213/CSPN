using CSPN.BLL;
using CSPN.common;
using CSPN.IBLL;
using CSPN.Model;
using Quartz;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CSPN.job
{
    public class UpdateNotReportNumJob : IJob
    {
        private IWellInfoService wellInfoService = new WellInfoService();
        private List<ReportInfo> list = new List<ReportInfo>();
        private string dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        private bool isEnabled = Convert.ToBoolean(ReadWriteXml.ReadXml("ReportInterval").Split('-')[0]);
        private int reportInterval = int.Parse(ReadWriteXml.ReadXml("ReportInterval").Split('-')[1]);

        Task IJob.Execute(IJobExecutionContext context)
        {
            list = wellInfoService.GetReportInfo();
            if (isEnabled)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if ((DateTime.Parse(dateTime) - DateTime.Parse(list[i].WellCurrentStateInfo.Report_Time.Trim())).Hours > reportInterval)
                    {
                        wellInfoService.UpdateNotReportTimes(list[i].WellCurrentStateInfo.Terminal_ID.Trim());
                        Thread.Sleep(500);
                    }
                }
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if ((DateTime.Parse(dateTime) - DateTime.Parse(list[i].WellCurrentStateInfo.Report_Time.Trim())).Hours > list[i].ReportInterval)
                    {
                        wellInfoService.UpdateNotReportTimes(list[i].WellCurrentStateInfo.Terminal_ID.Trim());
                        Thread.Sleep(500);
                    }
                }
            }
            wellInfoService.Empty_ReportNumInfo();
            return Task.FromResult(true);
        }
    }
}