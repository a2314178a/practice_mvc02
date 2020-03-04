﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using practice_mvc02.filters;
using practice_mvc02.Models;
using practice_mvc02.Models.dataTable;
using practice_mvc02.Repositories;

namespace practice_mvc02.Controllers
{
    [TypeFilter(typeof(ActionFilter))]
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
            return selectPage(type);
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
            return Repository.IgnorePunchLogWarn(punchLogID);
        }

        #endregion //punchWarn
        
        //--------------------------------------------------------------------------------------------------------

        #region  LeaveOffice

        public object getEmployeeApplyLeave(int page=0){
            return Repository.GetEmployeeApplyLeave((int)loginID, page);
        }

        public int isAgreeApplyLeave(int applyLeaveID, int isAgree){
            return Repository.IsAgreeApplyLeave(applyLeaveID, isAgree, (int)loginID);
        }

        #endregion //leaveOffice
        
    }
}
