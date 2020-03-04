using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Pomelo.AspNetCore.TimedJob;
using practice_mvc02.Models.dataTable;
using practice_mvc02.Repositories;

namespace practice_mvc02.Models
{
    public class RefreshPunchLogWarnJob : Job
    {
        public PunchCardRepository Repository { get; }
        public punchCardFunction punchCardFn {get;}


        public RefreshPunchLogWarnJob(PunchCardRepository repository, IHttpContextAccessor httpContextAccessor){
            this.Repository = repository;
            this.punchCardFn = new punchCardFunction(repository, httpContextAccessor);
        }


        // Begin 起始時間；Interval執行時間間隔，單位是毫秒，建議使用以下格式，ex:3小時(1000 * 3600 * 3)；
        //SkipWhileExecuting是否等待上一個執行完成，true為等待；
        //[Invoke(Begin = "2016-11-29 22:10", Interval = 1000 * 3600*3, SkipWhileExecuting =true)]
        [Invoke(Begin = "2020-02-21 00:00", Interval = 5000, SkipWhileExecuting =true, IsEnabled = false)]
        public void Run()
        {
            addPunchLogWhenNoPunch();
            punchCardProcess();
            Console.WriteLine(DateTime.Now); 
        }

        private void addPunchLogWhenNoPunch(){
            var targetDate = (DateTime.Now.Date).AddDays(-1);
            var spDate = Repository.GetThisSpecialDate(targetDate);
            List<Account> needPunchAcc = new List<Account>(){};

            if(spDate == null){
                if((targetDate.DayOfWeek.ToString("d")== "0" || targetDate.DayOfWeek.ToString("d")== "6")){
                    return;
                }else{
                    needPunchAcc = Repository.GetNeedPunchAcc();
                }
            }else{
                if(spDate.status == 1){
                    return;
                }else{
                    needPunchAcc = Repository.GetNeedPunchAcc();
                }
            }

            foreach(var employee in needPunchAcc){
                var logData = Repository.GetWorkDatePunchLog(employee.ID, targetDate);
                if(logData == null){
                    Repository.AddNullPunchLog(employee.ID, employee.departmentID, targetDate);
                }
            }
        }

        private void punchCardProcess(){
            List<PunchCardLog> warnLog = new List<PunchCardLog>();
            warnLog = Repository.GetAllPunchLogWithWarn();
            
            foreach (PunchCardLog log in warnLog){
                WorkTimeRule thisWorkTime = Repository.GetThisWorkTime(log.accountID);
                punchCardFn.processPunchlogWarn(log, thisWorkTime);
            }   
        }





    }
}