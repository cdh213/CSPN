using CSPN.helper;
using CSPN.job;

namespace CSPN.common
{
    public class QuartzInit
    {
        QuartzHelper quartzHelper = new QuartzHelper();
        public void Quartz()
        {
            //删除日志
            quartzHelper.WithIntervalInHours(typeof(DeleteLogJob), 1);
            //更新未上报次数
            quartzHelper.init(typeof(UpdateNotReportNumJob), 00, 30);
            //刷新人井信息列表
            quartzHelper.WithIntervalInMinutes(typeof(RefreshWellInfoJob), int.Parse(ReadWriteConfig.ReadConfig("RefreshTime")));
            //人井维护
            quartzHelper.WithIntervalInMinutes(typeof(MaintainInfoJob), 5);
        }
    }
}
