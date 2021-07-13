using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using practice_mvc02.Repositories;
using Quartz;


namespace practice_mvc02.Models.job
{
    [DisallowConcurrentExecution]
    public class MyJob : IJob
    {
        private CalAnnualLeave calSpLeave {set; get;}
        private CalWorkTime calTime {set; get;}
        private ChkPunchLogWarn chkWarn {set; get;}

        IServiceProvider _serviceProvider {set; get;}

        public MyJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task Execute(IJobExecutionContext context)
        { 
            using (var scope = _serviceProvider.CreateScope()) {
                var annualRe = scope.ServiceProvider.GetRequiredService(typeof(AnnualLeaveRepository)) as AnnualLeaveRepository;
                var punchRe = scope.ServiceProvider.GetRequiredService(typeof(PunchCardRepository)) as PunchCardRepository;
                var applyOtRe  =scope.ServiceProvider.GetRequiredService(typeof(ApplyOvertimeRepository)) as ApplyOvertimeRepository;
                var httpContext  =scope.ServiceProvider.GetRequiredService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
                calSpLeave = new CalAnnualLeave(annualRe);
                calTime = new CalWorkTime(punchRe, applyOtRe, httpContext);
                chkWarn = new ChkPunchLogWarn(punchRe, httpContext);
               
                var errorJob = "other";
                try{
                    Console.WriteLine($"{definePara.dtNow()}  start job");
                    errorJob = "calSpLeave";
                    calSpLeave.start();
                    errorJob = "calworkTime";
                    calTime.start();
                    errorJob = "chkWarn";
                    chkWarn.start();
                    Console.WriteLine($"{definePara.dtNow()}  end job");
                }catch(Exception ex){
                    string docPath = Environment.CurrentDirectory;
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "errorLog.txt"), true)){
                        var str = $"{definePara.dtNow()} - MyJob:{errorJob}   ";
                        outputFile.WriteLine(str + ex.ToString() + "\r\n");
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}