﻿using CSPN.BLL;
using CSPN.common;
using CSPN.helper;
using CSPN.IBLL;
using CSPN.Model;
using Quartz;
using System;
using System.Collections.Generic;
using System.Threading;

namespace CSPN.job
{
    public class UpdateNotReportNumJob : IJob
    {
        IWellInfoService wellInfoService = new WellInfoService();
        List<ReportInfo> list = new List<ReportInfo>();
        string dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        bool isEnabled = Convert.ToBoolean(ReadWriteXml.ReadXml("ReportInterval").Split('-')[0]);
        int reportInterval = int.Parse(ReadWriteXml.ReadXml("ReportInterval").Split('-')[1]);

        public void Execute(IJobExecutionContext context)
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
            LogHelper.WriteQuartzLog("更新人井未上报次数。时间:" + dateTime);
        }
    }
}
