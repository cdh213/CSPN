using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSPN.helper
{
    public class QuartzHelper
    {
        private IScheduler scheduler = null;

        /// <summary>
        /// 初始化定时器。
        /// 现在开始，每second秒触发一次。
        /// 不间断重复执行。
        /// </summary>
        /// <param name="jobType">要执行的作业</param>
        /// <param name="second">触发时间</param>
        public void init(Type jobType, int second)
        {
            //释放定时器  
            release();
            //工厂
            ISchedulerFactory factory = new StdSchedulerFactory();
            //创建scheduler
            if (scheduler == null)
                scheduler = factory.GetScheduler();
            //启动
            scheduler.Start();
            //描述工作
            IJobDetail job = JobBuilder.Create(jobType)
                                       .WithIdentity("myJob", "myGroup")
                                       .UsingJobData("name", "quartz").Build();
            ITrigger trigger = TriggerBuilder.Create()
                                       .WithIdentity("myJobtrigger", "myGroup")
                                       .StartNow()                        //现在开始
                                       .WithSimpleSchedule(x => x         //触发时间，5秒一次。
                                           .WithIntervalInSeconds(second)
                                           .RepeatForever())              //不间断重复执行
                                       .Build();

            //执行  
            scheduler.ScheduleJob(job, trigger);
        }
        /// <summary>
        /// 初始化定时器。
        /// 每天定时执行。
        /// </summary>
        /// <param name="jobType">要执行的作业</param>
        /// <param name="hour">小时</param>
        /// <param name="minute">分钟</param>
        public void init(Type jobType, int hour, int minute)
        {
            //释放定时器
            release();
            //工厂
            ISchedulerFactory factory = new StdSchedulerFactory();
            //创建scheduler
            if (scheduler == null)
                scheduler = factory.GetScheduler();
            //启动
            scheduler.Start();
            //描述工作
            IJobDetail job = JobBuilder.Create(jobType)
                                       .WithIdentity("myJob", "myGroup")
                                       .UsingJobData("name", "quartz").Build();
            //触发器  
            ITrigger trigger = null;
            //每天定时执行  
            trigger = TriggerBuilder.Create()
                                    .WithIdentity("myJobtrigger", "myGroup")
                                    .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(hour, minute))
                                    .Build();
            //执行  
            scheduler.ScheduleJob(job, trigger);
        }
        /// <summary>  
        /// 初始化定时器。
        /// 每周星期几定时执行。
        /// </summary>
        /// <param name="jobType">要执行的作业</param>
        /// <param name="weekday">星期几</param>
        /// <param name="hour">小时</param>
        /// <param name="minute">分钟</param>
        public void init(Type jobType, string weekday, int hour, int minute)
        {
            //释放定时器  
            release();
            //工厂  
            ISchedulerFactory factory = new StdSchedulerFactory();
            //启动  
            if (scheduler == null)
                scheduler = factory.GetScheduler();
            //启动  
            scheduler.Start();
            //描述工作  
            IJobDetail job = JobBuilder.Create(jobType).WithIdentity("myJob", "myGroup").UsingJobData("name", "quartz").Build();
            //触发器  
            ITrigger trigger = null;
            //每周星期几定时执行
            DayOfWeek wday = (DayOfWeek)System.Enum.Parse(typeof(DayOfWeek), weekday);
            trigger = TriggerBuilder.Create()
            .WithIdentity("myJobtrigger", "myGroup")
            .WithSchedule(CronScheduleBuilder.WeeklyOnDayAndHourAndMinute(wday, hour, minute))//每周相应时间执行  
            .Build();
            //执行  
            scheduler.ScheduleJob(job, trigger);
        }
        /// <summary>
        /// 初始化定时器。
        /// 某年某月某日某时某分某秒定时执行。
        /// </summary>
        /// <param name="jobType">要执行的作业</param>
        public void init(Type jobType, string year, string month, string day, string hour, string minute, string second)
        {
            //释放定时器  
            release();
            //工厂  
            ISchedulerFactory factory = new StdSchedulerFactory();
            //启动  
            if (scheduler == null)
                scheduler = factory.GetScheduler();
            //启动  
            scheduler.Start();
            //描述工作  
            IJobDetail job = JobBuilder.Create(jobType).WithIdentity("myJob", "myGroup").UsingJobData("name", "quartz").Build();
            //job.JobDataMap.Put("test", val);
            //触发器  
            ITrigger trigger = null;

            trigger = TriggerBuilder.Create()
            .WithIdentity("myJobtrigger", "myGroup")
            .WithSchedule(CronScheduleBuilder.CronSchedule("" + second + " " + minute + " " + hour + " " + day + " " + month + " ? " + year + ""))//具体时间执行  
            .Build();
            //执行  
            scheduler.ScheduleJob(job, trigger);
        }

        /// <summary>  
        /// 释放定时器  
        /// </summary>  
        void release()
        {
            if (scheduler != null && !scheduler.IsShutdown)
            {
                scheduler.Shutdown(true);
                scheduler = null;
            }
        }
        /// <summary>
        /// 关闭调度器
        /// </summary>
        public void Close()
        {
            if (!scheduler.IsShutdown)
            {
                scheduler.Shutdown(true);
            }
        }
    }
}
