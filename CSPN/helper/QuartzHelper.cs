using Quartz;
using Quartz.Impl;
using System;

namespace CSPN.helper
{
    public class QuartzHelper
    {
        private ISchedulerFactory factory = null;

        /// <summary>
        /// 初始化定时器。
        /// 现在开始，每minutes分钟触发一次。
        /// 不间断重复执行。
        /// </summary>
        /// <param name="jobType">要执行的作业</param>
        /// <param name="second">触发时间</param>
        public void WithIntervalInMinutes(Type jobType, int minutes)
        {
            //工厂
            factory = new StdSchedulerFactory();
            //创建scheduler
            IScheduler scheduler = factory.GetScheduler();
            //启动
            scheduler.Start();
            //描述工作
            IJobDetail job = JobBuilder.Create(jobType)
                                       .WithIdentity(jobType.Name, "myGroup")
                                       .UsingJobData("name", "quartz").Build();
            ITrigger trigger = TriggerBuilder.Create()
                                       .WithIdentity(jobType.Name + "trigger", "myGroup")
                                       .StartNow()                        //现在开始
                                       .WithSimpleSchedule(x => x         //触发时间
                                           .WithIntervalInMinutes(minutes)
                                           .RepeatForever())              //不间断重复执行
                                       .Build();

            //执行  
            scheduler.ScheduleJob(job, trigger);
        }
        /// <summary>
        /// 初始化定时器。
        /// 现在开始，每hours小时触发一次。
        /// 不间断重复执行。
        /// </summary>
        /// <param name="jobType">要执行的作业</param>
        /// <param name="second">触发时间</param>
        public void WithIntervalInHours(Type jobType, int hours)
        {
            //工厂
            factory = new StdSchedulerFactory();
            //创建scheduler
            IScheduler scheduler = factory.GetScheduler();
            //启动
            scheduler.Start();
            //描述工作
            IJobDetail job = JobBuilder.Create(jobType)
                                       .WithIdentity(jobType.Name, "myGroup")
                                       .UsingJobData("name", "quartz").Build();
            ITrigger trigger = TriggerBuilder.Create()
                                       .WithIdentity(jobType.Name + "trigger", "myGroup")
                                       .StartNow()                        //现在开始
                                       .WithSimpleSchedule(x => x         //触发时间
                                           .WithIntervalInHours(hours)
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
            //工厂
            factory = new StdSchedulerFactory();
            //创建scheduler
            IScheduler scheduler = factory.GetScheduler();
            //启动
            scheduler.Start();
            //描述工作
            IJobDetail job = JobBuilder.Create(jobType)
                                       .WithIdentity(jobType.Name, "myGroup")
                                       .UsingJobData("name", "quartz").Build();
            //触发器  
            ITrigger trigger = null;
            //每天定时执行  
            trigger = TriggerBuilder.Create()
                                    .WithIdentity(jobType.Name + "trigger", "myGroup")
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
        public void init(Type jobType, DayOfWeek dayOfWeek, int hour, int minute)
        {
            //工厂  
            factory = new StdSchedulerFactory();
            //创建scheduler
            IScheduler scheduler = factory.GetScheduler();
            //启动  
            scheduler.Start();
            //描述工作  
            IJobDetail job = JobBuilder.Create(jobType).WithIdentity(jobType.Name, "myGroup").UsingJobData("name", "quartz").Build();
            //触发器  
            ITrigger trigger = null;
            //每周星期几定时执行
            trigger = TriggerBuilder.Create()
            .WithIdentity(jobType.Name + "trigger", "myGroup")
            .WithSchedule(CronScheduleBuilder.WeeklyOnDayAndHourAndMinute(dayOfWeek, hour, minute))//每周相应时间执行  
            .Build();
            //执行  
            scheduler.ScheduleJob(job, trigger);
        }
        /// <summary>
        /// 初始化定时器。
        /// 某年某月某日某时某分某秒定时执行。
        /// </summary>
        /// <param name="jobType">要执行的作业</param>
        public void init(Type jobType, int year, int month, int day, int hour, int minute, int second)
        {
            //工厂  
            factory = new StdSchedulerFactory();
            //创建scheduler
            IScheduler scheduler = factory.GetScheduler();
            //启动  
            scheduler.Start();
            //描述工作  
            IJobDetail job = JobBuilder.Create(jobType).WithIdentity(jobType.Name, "myGroup").UsingJobData("name", "quartz").Build();
            //job.JobDataMap.Put("test", val);
            //触发器  
            ITrigger trigger = null;

            trigger = TriggerBuilder.Create()
            .WithIdentity(jobType.Name + "trigger", "myGroup")
            .WithSchedule(CronScheduleBuilder.CronSchedule("" + second + " " + minute + " " + hour + " " + day + " " + month + " ? " + year + ""))//具体时间执行  
            .Build();
            //执行  
            scheduler.ScheduleJob(job, trigger);
        }
    }
}
