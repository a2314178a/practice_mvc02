using System;
using System.Collections.Generic;
using System.Linq;
using practice_mvc02.Models.dataTable;

namespace practice_mvc02.Repositories
{
    public class PunchCardRepository : BaseRepository
    {
        const int lessStHour = -2;
        const int addEtHour = 13;

        public PunchCardRepository(DBContext dbContext):base(dbContext)
        {
            
        }

        public PunchCardLog GetTodayPunchLog(int employeeID, WorkTimeRule thisWorkTime){
            //
            DateTime sDateTime = DateTime.Now.Date;
            DateTime eDateTime = DateTime.Now.Date;
            if(thisWorkTime != null){
                sDateTime = DateTime.Now.Date + thisWorkTime.startTime;
                eDateTime = DateTime.Now.Date + thisWorkTime.endTime;
                eDateTime = eDateTime <= sDateTime ? eDateTime.AddDays(1): eDateTime;
                sDateTime = sDateTime.AddHours(lessStHour);
                eDateTime = eDateTime.AddHours(addEtHour);
                if(DateTime.Now >= eDateTime){
                    sDateTime.AddDays(1);
                    eDateTime.AddDays(1);
                }else if(DateTime.Now < sDateTime){
                    sDateTime.AddDays(-1);
                    eDateTime.AddDays(-1);
                }
            }else{
                eDateTime = eDateTime.AddDays(1);
            }
            PunchCardLog result = null;
            var query = from a in _DbContext.punchcardlogs
                        where a.accountID == employeeID && 
                        (a.onlineTime < eDateTime && a.onlineTime >= sDateTime ||
                        a.offlineTime <= eDateTime && a.offlineTime > sDateTime)
                        select a;

            if(query.Count() > 0){
                result = query.ToList()[0];
            }
            return result;
        }

        public object GetAllPunchLogByID(int employeeID){
            var query = from a in _DbContext.punchcardlogs
                        where a.accountID == employeeID
                        orderby a.logDate
                        select new{
                            a.ID, a.logDate, a.onlineTime, a.offlineTime, a.punchStatus
                        };
            return query.ToList();
        }

        public int AddPunchCardLog(PunchCardLog newData){
            int count = 0;
            var query = _DbContext.punchcardlogs.Where(b=>b.accountID == newData.accountID && b.logDate == newData.logDate);
            if(query.Count() > 0){
                return 1062;    //該日期已有紀錄
            }
            _DbContext.punchcardlogs.Add(newData);
            count = _DbContext.SaveChanges();
            return count;
        }

        public int UpdatePunchCard(PunchCardLog updateData){
            int count = 0;
            var query = _DbContext.punchcardlogs.Where(b=>b.accountID == updateData.accountID && 
                                                        b.logDate == updateData.logDate && b.ID != updateData.ID);
            if(query.Count() > 0){
                return 1062;    //該日期已有紀錄
            }
            PunchCardLog context = _DbContext.punchcardlogs.FirstOrDefault(b=>b.ID == updateData.ID);
            if(context != null){
                context.logDate = updateData.logDate;
                context.onlineTime = updateData.onlineTime;
                context.offlineTime = updateData.offlineTime;
                context.punchStatus = updateData.punchStatus;
                context.lastOperaAccID = updateData.lastOperaAccID;
                context.updateTime = updateData.updateTime;
                count = _DbContext.SaveChanges();
            }
            return count;
        }

        public int DelPunchCardLog(int punchLogID){
            int count = 0;
            var context = _DbContext.punchcardlogs.FirstOrDefault(b=>b.ID == punchLogID);
            if(context != null){
                _DbContext.Remove(context);
                count = _DbContext.SaveChanges();
            }
            return count;
        }


        public int GetThisLogAccID(int logID){
            int result = 0;
            var context = _DbContext.punchcardlogs.FirstOrDefault(b=>b.ID == logID);
            if(context != null){
                result = context.accountID;
            }
            return result;
        }

        public WorkTimeRule GetThisWorkTime(int employeeID){
            WorkTimeRule result = null;
            var query = from a in _DbContext.accounts
                        join b in _DbContext.worktimerules on a.timeRuleID equals b.ID
                        where a.ID == employeeID
                        select b;
            if(query.Count()>0){
                result = query.ToList()[0];
            }
            return result;
        }

        public void AddPunchLogWarn(PunchCardLog log){
            var principalID = (from a in _DbContext.departments 
                                join b in _DbContext.punchcardlogs on a.ID equals b.departmentID
                                where b.ID == log.ID
                                select a.principalID).FirstOrDefault();
            var warnLog = new PunchLogWarn();
            warnLog.accountID = log.accountID;
            warnLog.principalID = principalID;
            warnLog.punchLogID = log.ID;
            warnLog.warnStatus = 0;
            warnLog.createTime = DateTime.Now;
            var context = _DbContext.punchlogwarns.FirstOrDefault(b=>b.punchLogID == log.ID);
            if(context == null){
                _DbContext.punchlogwarns.Add(warnLog);
                _DbContext.SaveChanges();
            }
        }




        public void updatePunchLogWarn(int punchLogID){
            var context = _DbContext.punchlogwarns.FirstOrDefault(b=>b.punchLogID == punchLogID);
            if(context != null){
                context.warnStatus = 1;
                context.updateTime = DateTime.Now;
                _DbContext.SaveChanges();
            }
        }



        public List<PunchCardLog> GetAllPunchLogWithWarn(){
            var dtNow = DateTime.Now;
            var dtRange = dtNow.AddDays(-7);

            var query = _DbContext.punchcardlogs.Where(b=>(b.punchStatus == 0 || b.offlineTime.Year == 1) && b.logDate > dtRange);
                                                        
            return query.ToList();
        }

    }
}