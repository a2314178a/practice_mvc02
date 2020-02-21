using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using practice_mvc02.Models.dataTable;

namespace practice_mvc02.Repositories
{
    public class ApplySignRepository : BaseRepository
    {
        public ApplySignRepository(DBContext dbContext):base(dbContext)
        {
            
        }

        #region punchWarn

        public object GetPunchLogWarn(int loginID){
            var query = from a in _DbContext.punchlogwarns
                        join b in _DbContext.punchcardlogs on a.punchLogID equals  b.ID
                        join c in _DbContext.accounts on b.accountID equals c.ID
                        where a.principalID == loginID && a.warnStatus <2
                        select new{
                            c.userName, b.ID, b.logDate, b.onlineTime, b.offlineTime, b.punchStatus, a.warnStatus
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

        public object GetMyApplyLeave(int loginID, int page){
            var selStatus = page == 0? 1 : 3;   //0: 待審 1:通過 2:不通過
            var query = _DbContext.leaveofficeapplys.Where(b=>b.accountID == loginID && b.applyStatus < selStatus).Select(
                b=> new{b.ID, b.applyType, b.note, b.startTime, b.endTime, b.applyStatus, b.createTime}
            );
            return query.ToList();
        }

        public object GetEmployeeApplyLeave(int loginID, int page){
            var selStatus = page == 0? 1 : 3;   //0: 待審 1:通過 2:不通過
            /*var query = _DbContext.leaveofficeapplys.Where(b=>b.principalID == loginID && b.applyStatus < selStatus).Select(
                b=> new{b.ID, b.applyType, b.note, b.startTime, b.endTime, b.applyStatus, b.createTime}
            );*/
            var query = from a in _DbContext.leaveofficeapplys
                        join b in _DbContext.accounts on a.accountID equals b.ID
                        where a.principalID == loginID && a.applyStatus < 3
                        orderby b.createTime descending
                        select new{
                            a.ID, a.applyType, a.note, a.startTime, a.endTime, a.applyStatus, a.createTime, b.userName
                        };
            return query.ToList();
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
                context.applyType = updateApply.applyType;
                context.note = updateApply.note;
                context.startTime = updateApply.startTime;
                context.endTime = updateApply.endTime;
                context.lastOperaAccID = updateApply.lastOperaAccID;
                context.updateTime = updateApply.updateTime;
                count = _DbContext.SaveChanges();
            }
            return count;
        }

        public int IsAgreeApplyLeave(int applyID, int status, int loginID){
            int count = 0;
            var context = _DbContext.leaveofficeapplys.FirstOrDefault(b=>b.ID == applyID);
            if(context != null){
                context.applyStatus = status;
                context.lastOperaAccID = loginID;
                context.updateTime = DateTime.Now;
                count = _DbContext.SaveChanges();
            }
            return count;
        }


        #endregion //leaveOffice


    }
}