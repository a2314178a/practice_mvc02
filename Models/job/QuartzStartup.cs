using System;
using practice_mvc02.Models.job;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using Quartz.Spi;

namespace practice_mvc02.Models.job
{
    public class QuartzStartup
    {
        public IScheduler _scheduler { get; set; }
        private readonly IJobFactory iocJobfactory;
        public QuartzStartup(IServiceProvider IocContainer)
        {
            iocJobfactory = new MyJobFactory(IocContainer);
            var schedulerFactory = new StdSchedulerFactory();
            _scheduler = schedulerFactory.GetScheduler().Result;
            // 替換預設工廠
            _scheduler.JobFactory = iocJobfactory;
        }
        // Quartz.Net啟動後注冊job和trigger
        public void Start()
        {
            IJobDetail job = JobBuilder.Create<MyJob>()
                .WithIdentity("MyJob", "MyJobGroup")
                .Build();
    
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("MyJob", "MyJobGroup")
                .StartAt(DateTimeOffset.Parse("2021/07/01 00:00:00"))
                .WithCronSchedule("0 0 0 * * ?")
                .Build();

            //quartz在啟動時不會立即先執行排程
            ((CronTriggerImpl)trigger).MisfireInstruction = MisfireInstruction.CronTrigger.DoNothing;
            _scheduler.ScheduleJob(job, trigger).Wait();
            _scheduler.Start();
            // _scheduler.TriggerJob(new JobKey("MyJob"));
        }
    
        public void Stop()
        {
            if (_scheduler == null)
            {
                return;
            }
            if (_scheduler.Shutdown(waitForJobsToComplete: true).Wait(30000))
                _scheduler = null;
            else{}
        }

    }
}