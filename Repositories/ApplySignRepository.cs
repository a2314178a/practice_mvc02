using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using practice_mvc02.Models;
using practice_mvc02.Models.dataTable;

namespace practice_mvc02.Repositories
{
    public class ApplySignRepository : BaseRepository
    {
        private punchStatusCode psCode;
        public ApplySignRepository(DBContext dbContext):base(dbContext)
        {
            this.psCode = new punchStatusCode();
        }

        #region punchWarn

        public object GetPunchLogWarn(int loginID){
            var query =  from a in _DbContext.punchcardlogs
                         join b in _DbContext.punchlogwarns on a.ID equals b.punchLogID
                         join c in _DbContext.accounts on a.accountID equals c.ID
                         join d in _DbContext.employeeprincipals on a.accountID equals d.employeeID
                         where (d.principalID == loginID || d.principalAgentID == loginID) &&
                                a.accountID != loginID && b.warnStatus <2
                         orderby a.logDate descending
                         select new{
                            c.userName, a.ID, a.logDate, a.onlineTime, a.offlineTime, a.punchStatus, b.warnStatus
                        };
            return query.ToList();
        }

        public int IgnorePunchLogWarn(int punchLogID){
            int count = 0;
            var context = _DbContext.punchlogwarns.FirstOrDefault(b=>b.punchLogID == punchLogID);
            if(context != null){
                context.warnStatus = 2;
                count = _DbContext.SaveChanges();
            }
            return count;
        }

        #endregion //punchWarn

        //-----------------------------------------------------------------------------------------------------

       #region  LeaveOffice

        public object GetMyApplyLeave(int loginID, int page, DateTime sDate, DateTime eDate){
            var feDate = eDate.Year == 1? eDate.AddYears(9998) : eDate.AddDays(1);
            var selStatus = page == 0? 1 : 3;   //0: 待審 1:通過 2:不通過

            var query = from a in _DbContext.leavenames
                        join b in _DbContext.leaveofficeapplys on a.ID equals b.leaveID
                        where b.accountID == loginID && b.applyStatus < selStatus &&
                              b.createTime >= sDate && b.createTime < feDate
                        orderby b.createTime descending
                        select new{
                            a.leaveName, a.timeUnit,
                            b.ID, b.leaveID, b.note, b.startTime, b.endTime, b.applyStatus, b.createTime, b.unitVal, b.unit
                        };
            return query.ToList();
        }

        public object GetLeaveOption(){
            var query = _DbContext.leavenames.Select(b=>new{b.ID, b.leaveName, b.timeUnit});
            return query.ToList();
        }

        public object GetEmployeeApplyLeave(int loginID, int page){
            var selStatus = page == 0? 1 : 3;   //0: 待審 1:通過 2:不通過

            var query = from a in _DbContext.leaveofficeapplys
                        join b in _DbContext.accounts on a.accountID equals b.ID
                        join c in _DbContext.employeeprincipals on a.accountID equals c.employeeID
                        join d in _DbContext.leavenames on a.leaveID equals d.ID
                        where (c.principalID == loginID || c.principalAgentID == loginID) &&
                                a.accountID != loginID && a.applyStatus < 3
                        orderby a.createTime descending
                        select new{
                            a.ID, a.leaveID, a.note, a.startTime, a.endTime, a.applyStatus, a.createTime, 
                            b.userName, d.leaveName, d.timeUnit
                        };
            return query.ToList();
        }

        public string GetMyDepartClass(int loginID){
            var query = (from a in _DbContext.accounts
                        join b in _DbContext.departments on a.departmentID equals b.ID
                        join c in _DbContext.worktimerules on a.timeRuleID equals c.ID into tmp
                        from d in tmp.DefaultIfEmpty()
                        where a.ID == loginID
                        select new{b.department, d.name}).FirstOrDefault();
            return query != null? ($"全體,{query.department},{query.name}") : "全體";
        }

        public int CreateApplyLeave(LeaveOfficeApply newApply){
            int count = 0;
            try{
                _DbContext.leaveofficeapplys.Add(newApply);
                count = _DbContext.SaveChanges();
            }catch(Exception e){
                count = ((MySqlException)e.InnerException).Number;
            }
            return count;
        }

        public int DelApplyLeave(int applyLeaveID){
            int count = 0;
            var context = _DbContext.leaveofficeapplys.FirstOrDefault(b=>b.ID == applyLeaveID);
            if(context != null){
                _DbContext.Remove(context);
                count = _DbContext.SaveChanges();
            }
            return count;
        }

        public int UpdateApplyLeave(LeaveOfficeApply updateApply){
            int count = 0;
            var context = _DbContext.leaveofficeapplys.FirstOrDefault(b=>b.ID == updateApply.ID);
            if(context != null && context.applyStatus == 0){
                context.leaveID = updateApply.leaveID;
                context.note = updateApply.note;
                context.startTime = updateApply.startTime;
                context.endTime = updateApply.endTime;
                context.unitVal = updateApply.unitVal;
                context.unit = updateApply.unit;
                context.lastOperaAccID = updateApply.lastOperaAccID;
                context.updateTime = updateApply.updateTime;
                count = _DbContext.SaveChanges();
            }
            return count;
        }

        public LeaveOfficeApply IsAgreeApplyLeave(int applyID, int status, int loginID){
            int count = 0;
            var context = _DbContext.leaveofficeapplys.FirstOrDefault(b=>b.ID == applyID);
            if(context != null){
                context.applyStatus = status;
                context.lastOperaAccID = loginID;
                context.updateTime = DateTime.Now;
                count = _DbContext.SaveChanges();
            }
            return count == 1? context : null;
        }

        public void punchLogWithTakeLeave(LeaveOfficeApply restLog, int departID){
            var startDate = restLog.startTime.Date;
            var endDate = restLog.endTime.Date;
            do{
                var context = _DbContext.punchcardlogs.FirstOrDefault(b=>
                                        b.accountID == restLog.accountID && b.logDate == startDate);
                if(context != null){
                    context.lastOperaAccID = 0;
                    context.updateTime = DateTime.Now;
                    if(restLog.applyStatus == 1){
                        context.punchStatus = context.punchStatus == psCode.noWork? psCode.takeLeave : context.punchStatus |= psCode.takeLeave; 
                    }else{
                        context.punchStatus &= ~psCode.takeLeave;
                        if(context.logDate > DateTime.Now){
                            _DbContext.Remove(context);
                        }else{
                            if(context.onlineTime.Year ==1 && context.offlineTime.Year ==1){
                                context.punchStatus |= psCode.noWork;
                            }
                        }
                    }
                    _DbContext.SaveChanges();    
                }else{
                    if(restLog.applyStatus == 1){
                        PunchCardLog newLog = new PunchCardLog{
                            accountID = restLog.accountID, departmentID = departID,
                            logDate = startDate, createTime = DateTime.Now,
                            punchStatus = psCode.takeLeave
                        };
                        _DbContext.punchcardlogs.Add(newLog);
                        _DbContext.SaveChanges();
                    }
                }
                startDate = startDate.AddDays(1);
            }while(startDate <= endDate);
        }


        #endregion //leaveOffice


    }
}