using System.Collections.Generic;
using System.Linq;
using practice_mvc02.Models.dataTable;

namespace practice_mvc02.Repositories
{
    public class BaseRepository
    {
        protected DBContext _DbContext {get;set;}

        public BaseRepository(DBContext dbContext)
        {
            this._DbContext = dbContext;
        }

        public string QueryTimeStamp(int? id){
            string result = "";
            var query = _DbContext.accounts.Where(u=>u.ID == id).Select(u => u.loginTime);
            if(query.Count()>0){
                result = query.ToList()[0];                                                                             
            }
            return result; 
        }       

        public object GetAccountDetail(int employeeID){
            object result = null;
            var query = from a in _DbContext.accounts
                        join b in _DbContext.departments on a.departmentID equals b.ID
                        where a.ID == employeeID
                        select new{
                            a.account, a.userName, a.timeRuleID, a.groupID, a.accLV,
                            departmentID=b.ID, b.department, b.position
                        };
            if(query.Count()>0)
                result = query.ToList()[0];
            return result;
        }

        public object GetAllTimeRule(){
            object result = null;
            var query = (from a in _DbContext.worktimerules
                        orderby a.startTime
                        select new {
                            a.ID, a.name, a.startTime, a.endTime, a.lateTime
                        });
            result = query.ToList();
            return result;
        }

        public object GetAllGroup(){
            object result = null;
            var query = from a in _DbContext.grouprules
                        orderby a.ruleParameter
                        select new {
                            a.ID, a.groupName, a.ruleParameter
                        };
            result = query.ToList();
            return result;
        }

        //----------------------------------------------------------------------------------------
        
        
    }
}