using System;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;

namespace practice_mvc02.Models.job
{
    public class MyJobFactory : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public MyJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var jobType = bundle.JobDetail.JobType;
            // 從 DI 容器取出指定 Job Type 實體
            return _serviceProvider.GetRequiredService(jobType) as IJob;
        }

        public void ReturnJob(IJob job)
        {
            
        }
    }
}