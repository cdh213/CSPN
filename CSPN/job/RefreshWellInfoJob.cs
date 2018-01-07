using CSPN.helper;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.job
{
    public delegate void RefreshEventHandler();

    public class RefreshWellInfoJob : IJob
    {
        public static event RefreshEventHandler refreshEventHandler;

        public void Execute(IJobExecutionContext context)
        {
            if (refreshEventHandler != null)
            {
                refreshEventHandler();
                LogHelper.WriteQuartzLog("刷新信息列表。");
            }
        }
    }
}
