using System;
using System.Collections.Generic;
using Pomelo.AspNetCore.TimedJob;
using practice_mvc02.Models.dataTable;
using practice_mvc02.Repositories;

namespace practice_mvc02.Models
{
    public class RefreshPunchLogWarnJob : Job
    {
        public PunchCardRepository Repository { get; }
        public punchCardFunction punchCardFn {get;}


        public RefreshPunchLogWarnJob(PunchCardRepository repository){
            this.Repository = repository;
        }


        // Begin 起始時間；Interval執行時間間隔，單位是毫秒，建議使用以下格式，ex:3小時(1000 * 3600 * 3)；
        //SkipWhileExecuting是否等待上一個執行完成，true為等待；
        //[Invoke(Begin = "2016-11-29 22:10", Interval = 1000 * 3600*3, SkipWhileExecuting =true)]
        [Invoke(Begin = "2020-02-21 08:00", Interval = 5000, SkipWhileExecuting =true)]
        public void Run()
        {

            List<PunchCardLog> warnLog = new List<PunchCardLog>();
            warnLog = Repository.GetAllPunchLogWithWarn();
            
            foreach (PunchCardLog log in warnLog)
            {
               


            }   


            Console.WriteLine(DateTime.Now);
        }






    }
}