using System.Threading.Tasks;
using Quartz;

namespace CSPN.job
{
    public delegate void RefreshDelegate();

    public class RefreshWellInfoJob : IJob
    {
        public static event RefreshDelegate refreshEvent;

        Task IJob.Execute(IJobExecutionContext context)
        {
            if (refreshEvent != null)
            {
                refreshEvent();
            }
            return Task.FromResult(true);
        }
    }
}