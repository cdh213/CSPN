using CSPN.helper;
using CSPN.job;
using Quartz.Logging;

namespace CSPN.common
{
    public class QuartzInit
    {
        private QuartzHelper quartzHelper = new QuartzHelper();

        public void Quartz()
        {
            LogProvider.SetCurrentLogProvider(new LogHelper());

            //删除日志
            quartzHelper.WithIntervalInHours(typeof(DeleteLogJob), 1);
            //更新未上报次数
            quartzHelper.Init(typeof(UpdateNotReportNumJob), 00, 30);
            //刷新人井信息列表
            quartzHelper.WithIntervalInMinutes(typeof(RefreshWellInfoJob), int.Parse(ReadWriteXml.ReadXml("RefreshTime")));
            //人井维护
            quartzHelper.WithIntervalInMinutes(typeof(MaintainInfoJob), 1);
            //自动发送报警短信
            quartzHelper.WithIntervalInMinutes(typeof(AutoSendSMSJob), 3);
        }
    }
}