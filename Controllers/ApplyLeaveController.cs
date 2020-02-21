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
    public class ApplyLeaveController : BaseController
    {
        public ApplySignRepository Repository { get; }
        public loginFunction loginFn {get;}

        public ApplyLeaveController(ApplySignRepository repository, IHttpContextAccessor httpContextAccessor):base(httpContextAccessor)
        {
            this.Repository = repository;
            this.loginFn = new loginFunction(repository);
        }

        public IActionResult Index(string page)
        {           
            if(loginFn.isLoginInfo(loginID, loginAccLV) && (ruleVal & ruleCode.baseActive) > 0){
                return selectPage(page);
            }else{
                return RedirectToAction("logOut", "Home"); //轉址到特定Controller的ACTION名字
            }
        }

        public IActionResult selectPage(string page){
            ViewBag.ruleVal = ruleVal;
            ViewData["loginName"] = loginName;
            ViewBag.Auth = "Y";
            ViewBag.Page = page == "log" ? "log" : "apply";
            return View("ApplyLeavePage");  
        }

        //---------------------------------------------------------------------------------------
        
       
        #region  LeaveOffice

        public object getMyApplyLeave(int page=0){
            return Repository.GetMyApplyLeave((int)loginID, page);
        }



        public int createApplyLeave(LeaveOfficeApply newApply){
            if(!loginFn.chkCurrentUser(loginID, loginTimeStamp) || (ruleVal & ruleCode.baseActive)==0){
                return -2;
            }
            newApply.accountID = (int)loginID;
            newApply.principalID = (int)principalID;
            newApply.applyStatus = 0;
            newApply.createTime = DateTime.Now;
            newApply.lastOperaAccID = (int)loginID;
            return Repository.CreateApplyLeave(newApply);
        }

        public int delApplyLeave(int applyingID){
            if(!loginFn.chkCurrentUser(loginID, loginTimeStamp) || (ruleVal & ruleCode.baseActive)==0){
                return -2;
            }
            return Repository.DelApplyLeave(applyingID);
        }

        public int updateApplyLeave(LeaveOfficeApply updateApply){
            if(!loginFn.chkCurrentUser(loginID, loginTimeStamp) || (ruleVal & ruleCode.baseActive)==0){
                return -2;
            }
            updateApply.lastOperaAccID = (int)loginID;
            updateApply.updateTime = DateTime.Now;
            return Repository.UpdateApplyLeave(updateApply);
        }

        #endregion //leaveOffice
        
    }
}
