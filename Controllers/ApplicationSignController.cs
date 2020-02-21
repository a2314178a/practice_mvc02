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
    public class ApplicationSignController : BaseController
    {
        public ApplySignRepository Repository { get; }
        public loginFunction loginFn {get;}

        public ApplicationSignController(ApplySignRepository repository, IHttpContextAccessor httpContextAccessor):base(httpContextAccessor)
        {
            this.Repository = repository;
            this.loginFn = new loginFunction(repository);
        }

        public IActionResult Index(int type=1)
        {           
            if(loginFn.isLoginInfo(loginID, loginAccLV) && (ruleVal & ruleCode.applySign) > 0){
                return selectPage(type);
            }else{
                return RedirectToAction("logOut", "Home"); //轉址到特定Controller的ACTION名字
            }
        }

        public IActionResult selectPage(int type){
            ViewBag.ruleVal = ruleVal;
            ViewData["loginName"] = loginName;
            ViewBag.Auth = "Y";
            ViewBag.Page = type==2 ? "leave" : "punch";
            ViewBag.loginAccLV = loginAccLV;
            switch(type){
                case 1: 
                case 2: return View("ManagerSignPage");
                default: return RedirectToAction("logOut", "Home");
            }   
        }

        //---------------------------------------------------------------------------------------
        
        #region punchWarn
        
        public object getPunchLogWarn(){
            return Repository.GetPunchLogWarn((int)loginID);
        }

        public int ignorePunchLogWarn(int punchLogID){
            if(!loginFn.chkCurrentUser(loginID, loginTimeStamp) || (ruleVal & ruleCode.applySign)==0){
                return -2;
            }
            return Repository.IgnorePunchLogWarn(punchLogID);
        }

        #endregion //punchWarn
        
        //--------------------------------------------------------------------------------------------------------

        #region  LeaveOffice

        public object getEmployeeApplyLeave(int page=0){
            return Repository.GetEmployeeApplyLeave((int)loginID, page);
        }

        public int isAgreeApplyLeave(int applyLeaveID, int isAgree){
            if(!loginFn.chkCurrentUser(loginID, loginTimeStamp) || (ruleVal & ruleCode.applySign)==0){
                return -2;
            }
            return Repository.IsAgreeApplyLeave(applyLeaveID, isAgree, (int)loginID);
        }

        #endregion //leaveOffice
        
    }
}
