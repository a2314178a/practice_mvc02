using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Pomelo.AspNetCore.TimedJob;
using practice_mvc02.Models.dataTable;
using practice_mvc02.Repositories;

namespace practice_mvc02.Models
{
    public class countWorkTimeJob : Job
    {
        public PunchCardRepository Repository { get; }
        public punchCardFunction punchCardFn {get;}


        public countWorkTimeJob(PunchCardRepository repository, IHttpContextAccessor httpContextAccessor){
            this.Repository = repository;
            this.punchCardFn = new punchCardFunction(repository, httpContextAccessor);
        }


        // Begin 起始時間；Interval執行時間間隔，單位是毫秒，建議使用以下格式，ex:3小時(1000 * 3600 * 3)；
        //SkipWhileExecuting是否等待上一個執行完成，true為等待；
        //[Invoke(Begin = "2016-11-29 22:10", Interval = 1000 * 3600*3, SkipWhileExecuting =true)]
        [Invoke(Begin = "2020-02-21 00:00", Interval = 5000, SkipWhileExecuting =true, IsEnabled = false)]
        public void Run()
        {
            calEmployeeWorkTime();
            Console.WriteLine("---------------------------------"+DateTime.Now+"-----------------------------------"); 
        }

        private void calEmployeeWorkTime(){
            var workEmployee = Repository.GetNeedPunchAcc();
            var dtNow = DateTime.Now;
            var startDT = dtNow.AddDays(1 - dtNow.Day).Date;
            var endDT = startDT.AddMonths(1).AddDays(-1).Date;
            //var startDT = dtNow.AddMonths(-1).AddDays(1 - dtNow.Day).Date;
            //var endDT = startDT.AddMonths(1).AddDays(-1).Date;
            foreach(var employee in workEmployee){
                var thisMonthAllLog = Repository.GetPunchLogByDateByID(employee.ID, startDT, endDT);
                WorkTimeRule thisWorkTime = Repository.GetThisWorkTime(employee.ID);
                countWorkTime(thisMonthAllLog, thisWorkTime);
            }
        }


        private void countWorkTime(List<PunchCardLog> thisMonthAllLog, WorkTimeRule thisWorkTime){
            double totalTime = 0.0;
            double restTime = 1.0;
            object workTime = punchCardFn.workTimeProcess(thisWorkTime);
            DateTime sWorkDt = punchCardFn.getObjectValue("sWorkDt", workTime);
            DateTime eWorkDt = punchCardFn.getObjectValue("eWorkDt", workTime);
            var workAllTime = punchCardFn.getObjectValue("workAllTime", workTime);
            var sWorkTime = sWorkDt.TimeOfDay;
            var eWorkTime = eWorkDt.TimeOfDay;
            foreach(var log in thisMonthAllLog){
                if(log.onlineTime.Year == 1 || log.offlineTime.Year == 1 || log.onlineTime >= log.offlineTime){
                    continue;
                }
                var onlineTime = log.onlineTime.TimeOfDay;
                var offlineTime = log.offlineTime.TimeOfDay;
                var subStartTime = (log.punchStatus & 0x02)>0? onlineTime : sWorkTime;
                var subEndTime = (log.punchStatus & 0x04)>0? offlineTime : eWorkTime;
                if(log.punchStatus == 0x01){
                    totalTime += 8.0;
                }else{
                    var length = TimeSpan.Zero;
                    if(subEndTime < subStartTime){
                        length = subEndTime.Add(new TimeSpan(24,0,0)) - subStartTime;
                    }else{
                        length = subEndTime - subStartTime;
                    }
                    totalTime += length.Hours - restTime;
                    totalTime = length.Minutes >=30 ? totalTime+0.5 : totalTime;
                }
                saveTotalTimeRecord(log.accountID, totalTime);
            }

        }

        public void saveTotalTimeRecord(int accID, double totalTime){
            var timeRecord = new workTimeTotal();
            timeRecord.accountID = accID;
            timeRecord.dateMonth = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date;
            timeRecord.totalTime = totalTime;
            timeRecord.createTime = DateTime.Now;
            Repository.SaveTotalTimeRecord(timeRecord);
        }

     



    }
}