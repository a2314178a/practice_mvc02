using System;
using System.Collections.Generic;
using System.Linq;
using practice_mvc02.Models.dataTable;

namespace practice_mvc02.Repositories
{
    public class AccountRepository : BaseRepository
    {
        public AccountRepository(DBContext dbContext):base(dbContext)
        {
            
        }

        public Account Login(string account, string password)
        {
            Account result = null;
            var query = _DbContext.accounts.Where(b=>b.account == account && b.password == password);
            if(query.Count()>0){
                result = query.ToList()[0]; 
            }
            return result; 
        }

        public int UpdateTimeStamp(int id, string timeStamp, DateTime updateTime)
        {
            int count = 0;
            var userContext = _DbContext.accounts.FirstOrDefault(u=>u.ID == id);
            userContext.loginTime = timeStamp;
            userContext.updateTime = updateTime;
            count = _DbContext.SaveChanges();
            return count;
        }

        public int getThisGroupRuleVal(int groupID){
            var query = _DbContext.grouprules.FirstOrDefault(b=>b.ID == groupID);
            return query == null ? 0 : query.ruleParameter;
        }
        
    }
}