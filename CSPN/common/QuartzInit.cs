using CSPN.helper;
using CSPN.job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.common
{
    public class QuartzInit
    {
        QuartzHelper quartzHelper = new QuartzHelper();
        public void Quartz()
        {
            //删除日志
            quartzHelper.init(typeof(DeleteLogJob), 23, 30);
            //更新未上报次数
            quartzHelper.init(typeof(UpdateNotReportNumJob), 23, 30);
            //刷新人井信息列表
            quartzHelper.init(typeof(RefreshWellInfoJob), int.Parse(ReadWriteConfig.ReadConfig("RefreshTime")));
            //人井维护
            quartzHelper.init(typeof(MaintainInfoJob), 1);
        }
    }
}
