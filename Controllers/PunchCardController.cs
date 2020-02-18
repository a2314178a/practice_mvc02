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
    public class PunchCardController : BaseController
    {
        public PunchCardRepository Repository { get; }
        public loginFunction loginFn {get;}
        public punchCardFunction punchCardFn {get;}

        public PunchCardController(PunchCardRepository repository, IHttpContextAccessor httpContextAccessor):base(httpContextAccessor)
        {
            this.Repository = repository;
            this.loginFn = new loginFunction(repository);
            this.punchCardFn = new punchCardFunction(repository, httpContextAccessor);
        }

        public IActionResult Index(string page)
        {           
            if( loginFn.isLoginInfo(loginID, loginGroupID) && ((ruleVal & ruleCode.punchAndLog) > 0)){
                return selectPage(page);
            }else{
                return RedirectToAction("logOut", "Home"); //轉址到特定Controller的ACTION名字
            }
        }

        public IActionResult selectPage(string page){
            ViewBag.ruleVal = ruleVal;
            ViewData["loginName"] = loginName;
            ViewBag.Auth = "Y";
            ViewBag.loginAccLV = loginAccLV;
            ViewBag.Operator = "myself";
            ViewBag.punchLogName = loginName;
            ViewBag.canEditPunchLog = false;
            if(page == "log"){
                return View("PunchCardLogPage");
            }
            return View("PunchCardPage");
        }

        public IActionResult getEmployeeLog(int employeeID){
            if(loginFn.isLoginInfo(loginID, loginAccLV)){
                object accDetail = Repository.GetAccountDetail(employeeID);
                var employeeAccLV = accDetail.GetType().GetProperty("accLV").GetValue(accDetail);
                var employeeName = accDetail.GetType().GetProperty("userName").GetValue(accDetail);
                var employeeDepartID = accDetail.GetType().GetProperty("departmentID").GetValue(accDetail);
                ViewData["loginName"] = loginName;
                ViewBag.Auth = "Y";
                ViewBag.loginAccLV = loginAccLV;
                ViewBag.lookEmployeeID = employeeID;
                ViewBag.punchLogName = employeeName;
                ViewBag.lookEmployeeDepartID = employeeDepartID;
                ViewBag.ruleVal = ruleVal;
                ViewBag.canEditPunchLog = (ruleVal & ruleCode.editPunchLog)>0 ? true : false;
                return View("PunchCardLogPage");
            }else{
                return RedirectToAction("logOut", "Home"); //轉址到特定Controller的ACTION名字
            }
        }

        
        //---------------------------------------------------------------------------------------
        public object getTodayPunchStatus(){    //look my today PunchStatus
            WorkTimeRule thisWorkTime = Repository.GetThisWorkTime((int)loginID);
            var dataLog = Repository.GetTodayPunchLog((int)loginID, thisWorkTime);
            if(dataLog == null){
                dataLog = new PunchCardLog();
            }
            dynamic onlineTime = dataLog.onlineTime;
            dynamic offlineTime = dataLog.offlineTime;
            if(onlineTime.Year == 1){ onlineTime = false; }      
            if(offlineTime.Year == 1){ offlineTime = false; }
            return new {
                onlineTime = onlineTime, offlineTime = offlineTime,
            };
        }

        public int addPunchCardLog(int action, int employeeID = 0){
            if(!loginFn.chkCurrentUser(loginID, loginTimeStamp)){
                return -2;
            }
            if(employeeID == 0){
                employeeID = (int)loginID;
            }
            WorkTimeRule thisWorkTime = Repository.GetThisWorkTime(employeeID);
            PunchCardLog logData = Repository.GetTodayPunchLog(employeeID, thisWorkTime);
            return punchCardFn.punchCardProcess(logData, thisWorkTime, action, employeeID);
        }

        public object getAllPunchLogByID(int employeeID){
            if(employeeID == 0)
                employeeID = (int)loginID;
            return Repository.GetAllPunchLogByID(employeeID);
        }


        public int forceAddPunchCardLog(PunchCardLog newPunchLog){
            if(!loginFn.chkCurrentUser(loginID, loginTimeStamp) || (ruleVal & ruleCode.editPunchLog)==0){
                return -2;
            }
            if( newPunchLog.accountID == 0 || newPunchLog.departmentID == 0 || 
               (newPunchLog.onlineTime.Year == 1 && newPunchLog.offlineTime.Year == 1) ){
                  return 2; //此打卡紀錄不合法
            }
            WorkTimeRule thisWorkTime = Repository.GetThisWorkTime(newPunchLog.accountID);
            return punchCardFn.forcePunchLogProcess(newPunchLog, thisWorkTime, "add");
        }

        public int forceUpdatePunchCardLog(PunchCardLog updatePunchLog){
            if(!loginFn.chkCurrentUser(loginID, loginTimeStamp) || (ruleVal & ruleCode.editPunchLog)==0){
                return -2;
            }
            if( updatePunchLog.ID == 0 || (updatePunchLog.onlineTime.Year == 1 && updatePunchLog.offlineTime.Year == 1) ){
                  return 2; //此打卡紀錄不合法
            }
            updatePunchLog.accountID = Repository.GetThisLogAccID(updatePunchLog.ID);
            WorkTimeRule thisWorkTime = Repository.GetThisWorkTime(updatePunchLog.accountID);
            return punchCardFn.forcePunchLogProcess(updatePunchLog, thisWorkTime, "update");
        }

        public int delPunchCardLog(int punchLogID){
            if(!loginFn.chkCurrentUser(loginID, loginTimeStamp) || (ruleVal & ruleCode.editPunchLog)==0){
                return -2;
            }
            return Repository.DelPunchCardLog(punchLogID);
        }

        


        

        
    }
}
