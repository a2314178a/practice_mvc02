using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using practice_mvc02.Models.dataTable;

namespace practice_mvc02.Repositories
{
    public class MasterRepository : BaseRepository
    {
        public MasterRepository(DBContext dbContext):base(dbContext)
        {
            
        }

        #region employee CRUD

        public object GetThisLvAllAcc(int loginID, bool crossDepart, int loginAccLV, 
                                        string fName, string fDepart, string fPosition){
            object result = null;
            
            string departName = fDepart;
            if(!crossDepart){
                var query01 = from a in _DbContext.departments
                            join b in _DbContext.accounts on a.ID equals b.departmentID
                            where b.ID == loginID select a.department;
                departName = query01.Count()>0? query01.ToList()[0] : "有問題但不能回傳跨部門結果";
            }
            var query = from a in _DbContext.accounts
                        join b in _DbContext.departments on a.departmentID equals b.ID
                        join c in _DbContext.worktimerules on a.timeRuleID equals c.ID into tmp
                        from d in tmp.DefaultIfEmpty()
                        where a.userName.Contains(fName) &&  b.department.Contains(departName) && 
                                b.position.Contains(fPosition) && a.accLV <= loginAccLV 
                        orderby b.department
                        select new {
                            a.ID, a.account, a.userName,
                            b.department, b.position,  
                            //d.startTime, d.endTime
                        };
            result = query.ToList();
            
            return result;
        }

        public int CreateEmployee(Account newEmployee, EmployeeDetail newDetail){
            int count = 0;
            var context = _DbContext.accounts.FirstOrDefault(b=>b.account == newEmployee.account);
            if(context != null){
                return -1;  //had account
            }
            _DbContext.accounts.Add(newEmployee);
            count = _DbContext.SaveChanges();
            if(newEmployee.ID > 0){
                var context2 = _DbContext.employeedetails.FirstOrDefault(b=>b.accountID == newEmployee.ID);
                if(context2 == null){
                    newDetail.accountID = newEmployee.ID;
                    _DbContext.employeedetails.Add(newDetail);
                    _DbContext.SaveChanges();
                }
            }
            return count;
        }

        public int DelEmployee(int employeeID){
            int count = 0;
            var context = _DbContext.accounts.FirstOrDefault(b=>b.ID == employeeID);
            if(context != null){
                _DbContext.Remove(context);
                count = _DbContext.SaveChanges();
            }
            return count;
        }

        public int UpdateEmployee(Account updateData, EmployeeDetail upDetail){
            int count = 0;
            var context = _DbContext.accounts.FirstOrDefault(b=>b.ID == updateData.ID);
            if(context != null){
                if(updateData.password != null){
                    context.password = updateData.password;
                }
                context.userName = updateData.userName;
                context.departmentID = updateData.departmentID;
                context.accLV = updateData.accLV;
                context.timeRuleID = updateData.timeRuleID;
                context.groupID = updateData.groupID;
                context.lastOperaAccID = updateData.lastOperaAccID;
                context.updateTime = updateData.updateTime;
                count = _DbContext.SaveChanges();
            }
            var context2 = _DbContext.employeedetails.FirstOrDefault(b=>b.accountID == updateData.ID);
            if(context2 != null){
                context2.startWorkDate = upDetail.startWorkDate;
                context2.lastOperaAccID = upDetail.lastOperaAccID;
                context2.updateTime = upDetail.updateTime;
                _DbContext.SaveChanges();
            }
            return count;
        }
        
        public Account GetEmployeeAccByID(int ID){
            Account context = _DbContext.accounts.FirstOrDefault(b=>b.ID == ID);
            return context;
        }

        public object GetDepartOption(){
            var query = _DbContext.departments.Select(b=>b.department).Distinct();
            return query.ToList();
        }

        public object GetPositionOption(){
            var query = _DbContext.departments.Select(b=>b.position).Distinct();
            return query.ToList();
        }
        
        
        #endregion  //employee CRUD


        #region department CRUD

        public int CreateDepartment(Department newData){
            int count = 0;
            try{
                _DbContext.departments.Add(newData);
                count = _DbContext.SaveChanges();
            }catch(Exception e){
                count = ((MySqlException)e.InnerException).Number;
            }
            return count;
        }

        public int DelDepartment(int id){
            int count = 0;
            var context = _DbContext.departments.FirstOrDefault(b=>b.ID == id);
            if(context != null){
                _DbContext.departments.Remove(context);
                count = _DbContext.SaveChanges();
            }
            return count;
        }

        public int UpdateDepartment(Department updateDate){
            int count = 0;
            try{
                var context = _DbContext.departments.FirstOrDefault(b=>b.ID == updateDate.ID);
                context.department = updateDate.department;
                context.position = updateDate.position;
                context.principalID = updateDate.principalID;
                context.lastOperaAccID = updateDate.lastOperaAccID;
                context.updateTime = updateDate.updateTime;
                count = _DbContext.SaveChanges();
            }catch(Exception e){
                count = ((MySqlException)e.InnerException).Number;
            }
            return count;
        }

        public object GetThisDepartPosition(int loginID){
            object result = null;
            var query =  from a in _DbContext.departments
                         where (from b in _DbContext.accounts 
                                join c in _DbContext.departments on b.departmentID equals c.ID
                                where b.ID == loginID select c.department
                                ).Contains(a.department) select new{
                                    a.ID, a.department, a.position
                                };

            result = query.ToList();
            return result;
        }

        public object GetAllDepartPosition(){
            object result = null;
            var query = from a in _DbContext.departments
                        join b in _DbContext.accounts on a.principalID equals b.ID into tmp
                        from c in tmp.DefaultIfEmpty()
                        orderby a.department
                        select new {
                            a.ID, a.department, a.position, accID=a.principalID, c.userName, 
                        };
            result = query.ToList();
            return result;
        }

        public object GetAllPrincipal(){
            var query = from a in _DbContext.accounts
                        orderby a.accLV descending
                        select new{
                            a.ID, a.userName
                        };
            return query.ToList();
        }

        public object GetAllPosition(string department){
            object result = null;
            var query = (from a in _DbContext.departments
                        where a.department == department
                        orderby a.principalID
                        select new {
                            a.ID, a.position, a.principalID
                        });
            result = query.ToList();
            return result;
        }

        #endregion  //department CRUD

        
  
        
    }
}