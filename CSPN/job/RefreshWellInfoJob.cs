using CSPN.helper;
using Quartz;

namespace CSPN.job
{
    public delegate void RefreshDelegate();

    public class RefreshWellInfoJob : IJob
    {
        public static RefreshDelegate refreshDelegate;

        public void Execute(IJobExecutionContext context)
        {
            if (refreshDelegate != null)
            {
                refreshDelegate();
                LogHelper.WriteQuartzLog("刷新信息列表。");
            }
        }
    }
}