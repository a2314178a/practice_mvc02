using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using practice_mvc02.Models.dataTable;

namespace practice_mvc02.Repositories
{
    public class SetRuleRepository : BaseRepository
    {
        public SetRuleRepository(DBContext dbContext):base(dbContext)
        {
            
        }

        #region timeRule CRUD
        //in baseRepository
        /*public object GetAllTimeRule(){
            object result = null;
            var query = (from a in _DbContext.worktimerules
                        orderby a.startTime
                        select new {
                            a.ID, a.name, a.startTime, a.endTime, a.lateTime
                        });
            result = query.ToList();
            return result;
        }*/

        public int AddTimeRule(WorkTimeRule newRule){
            int count = 0;
            try{
                _DbContext.worktimerules.Add(newRule);
                count = _DbContext.SaveChanges();
            }catch(Exception e){
                count = ((MySqlException)e.InnerException).Number;
            }
            return count;
        }

        public int DelTimeRule(int id){
            int count = 0;
            var context = _DbContext.worktimerules.FirstOrDefault(b=>b.ID == id);
            if(context != null){
                _DbContext.worktimerules.Remove(context);
                count = _DbContext.SaveChanges();
            }
            return count;
        }

        public int UpdateTimeRule(WorkTimeRule updateData){
            int count = 0;
            try{
                var context = _DbContext.worktimerules.FirstOrDefault(b=>b.ID == updateData.ID);
                if(context != null){
                    context.name = updateData.name;
                    context.startTime = updateData.startTime;
                    context.endTime = updateData.endTime;
                    context.lateTime = updateData.lateTime;
                    context.lastOperaAccID = updateData.lastOperaAccID;
                    context.updateTime = updateData.updateTime;
                    count = _DbContext.SaveChanges();
                }
            }catch(Exception e){
                count = ((MySqlException)e.InnerException).Number;
            }
            return count;
        }

        #endregion

        //-----------------------------------------------------------------------------------------------------------

        #region Group
        //in baseRepository
        /*public object GetAllGroup(){
            object result = null;
            var query = from a in _DbContext.grouprules
                        select new {
                            a.ID, a.groupName, a.ruleParameter
                        };
            result = query.ToList();
            return result;
        }*/

        public int AddGroup(GroupRule newGroup){
            int count = 0;
            try{
                _DbContext.grouprules.Add(newGroup);
                count = _DbContext.SaveChanges();
            }catch(Exception e){
                count = ((MySqlException)e.InnerException).Number;
            }
            return count;
        }

        public int DelGroup(int id){
            int count = 0;
            var context = _DbContext.grouprules.FirstOrDefault(b=>b.ID == id);
            if(context != null){
                _DbContext.grouprules.Remove(context);
                count = _DbContext.SaveChanges();
            }
            return count;
        }

        public int UpdateGroup(GroupRule updateGroup){
            int count = 0;
            try{
                var context = _DbContext.grouprules.FirstOrDefault(b=>b.ID == updateGroup.ID);
                if(context != null){
                    context.groupName = updateGroup.groupName;
                    context.ruleParameter = updateGroup.ruleParameter;
                    context.lastOperaAccID = updateGroup.lastOperaAccID;
                    context.updateTime = updateGroup.updateTime;
                    count = _DbContext.SaveChanges();
                }
            }catch(Exception e){
                count = ((MySqlException)e.InnerException).Number;
            }
            return count;
        }


        #endregion
        
    }
}