using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using practice_mvc02.Models;
using practice_mvc02.Models.dataTable;
using practice_mvc02.Repositories;

namespace practice_mvc02.Controllers
{
    public class EmployeeListController : BaseController
    {
        public MasterRepository Repository { get; }
        public loginFunction loginFn {get;}

        public EmployeeListController(MasterRepository repository, IHttpContextAccessor httpContextAccessor):base(httpContextAccessor)
        {
            this.Repository = repository;
            this.loginFn = new loginFunction(repository);
        }

        public IActionResult Index()
        {           
            if(loginFn.isLoginInfo(loginID, loginGroupID) &&
             ((ruleVal & ruleCode.departEmployeeList) > 0 || (ruleVal & ruleCode.allEmployeeList) > 0)
            ){
                return selectPage();
            }else{
                return RedirectToAction("logOut", "Home"); //轉址到特定Controller的ACTION名字
            }
        }
        
        public IActionResult selectPage(){
            ViewBag.ruleVal = ruleVal;
            ViewBag.canEmployeeEdit = (ruleVal & ruleCode.employeeEdit) > 0 ? true : false;
            ViewData["loginName"] = loginName;
            ViewBag.Auth = "Y";
            ViewBag.loginAccLV = loginAccLV;
            return View("EmployeeListPage");
        }
 
        //--------------------------------------------------------------------------------
        #region employee
        public object getThisLvAllAcc(){
            var crossDepart = ((ruleVal & ruleCode.allEmployeeList) > 0)? true: false;
            return Repository.GetThisLvAllAcc(loginID, crossDepart, (int)loginAccLV);
        }

        public object getAccountDetail(int employeeID){
            return Repository.GetAccountDetail(employeeID);
        }
        
        public int createEmployee(Account newEmployee){
            if(!loginFn.chkCurrentUser(loginID, loginTimeStamp) || (ruleVal & ruleCode.employeeEdit)==0){
                return -2;
            }
            newEmployee.password = loginFn.GetMD5(newEmployee.account + newEmployee.password);
            newEmployee.lastOperaAccID = (int)loginID;
            newEmployee.createTime = DateTime.Now;
            return Repository.CreateEmployee(newEmployee);  //-2:mulUserlongin -1:already account, 0:add fail, 1:add success
        }

        public int delEmployee(int employeeID){
            if(!loginFn.chkCurrentUser(loginID, loginTimeStamp) || (ruleVal & ruleCode.employeeEdit)==0){
                return -2;
            }
            return Repository.DelEmployee(employeeID);
        }

        public int updateEmployee(Account updateData){
            if(!loginFn.chkCurrentUser(loginID, loginTimeStamp) || (ruleVal & ruleCode.employeeEdit)==0){
                return -2;
            }
            if(updateData.password != null){
                updateData.password = loginFn.GetMD5((updateData.account + updateData.password));
            }
            updateData.lastOperaAccID = (int)loginID;
            updateData.updateTime = DateTime.Now;
            return Repository.UpdateEmployee(updateData);
        }
        #endregion

        //----------------------------------------------------------------------------------------

        #region subWindow
        public IActionResult showAddForm(int? ID = null){
            if(!loginFn.isLoginInfo(loginID, loginGroupID) ||
             ((ruleVal & ruleCode.employeeEdit) == 0)
            ){
                return RedirectToAction("logOut", "Home"); //轉址到特定Controller的ACTION名字
            }
            ViewBag.ruleVal = ruleVal;
            ViewBag.loginAccLV = loginAccLV;
            if(ID == null){
                ViewBag.Action = "add";
                ViewBag.mainText = "新增人員";
            }else{     
                ViewBag.Action = "update";
                ViewBag.mainText = "編輯員工";
                ViewBag.ID = ID;   
            }
            return View("subPage/addUpdateForm");
        }

        public object getSelOption(){
            object departOption = null;
            if((ruleVal & ruleCode.allEmployeeList) > 0){
                departOption = Repository.GetAllDepartPosition();
            }else{
                departOption = Repository.GetThisDepartPosition((int)loginID);
            }
            object timeOption = Repository.GetAllTimeRule();
            object groupOption = Repository.GetAllGroup();
            return new{departOption=departOption, timeOption=timeOption, groupOption=groupOption};
        }
        
        #endregion







    }



}
