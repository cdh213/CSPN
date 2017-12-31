using CSPN.BLL;
using CSPN.helper;
using CSPN.IBLL;
using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.job
{
    public class UpdateNotReportNumJob : IJob
    {
        IWellInfoService wellInfoService = new WellInfoService();

        public void Execute(IJobExecutionContext context)
        {
            wellInfoService.UpdateNotReportTimes();
            wellInfoService.Empty_ReportNumInfo();
            LogHelper.WriteQuartzLog("更新人井未上报次数。");
        }
    }
}
