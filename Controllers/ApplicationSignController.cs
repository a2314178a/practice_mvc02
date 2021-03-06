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
        public MasterRepository mRepository { get; }
        
        public ApplicationSignController(ApplySignRepository repository, MasterRepository masterRepository,
                                        IHttpContextAccessor httpContextAccessor):base(httpContextAccessor)
        {
            this.Repository = repository;
            this.mRepository = masterRepository;
        }

        public IActionResult Index(int type=1)
        {              
            return selectPage(type);
        }

        public IActionResult selectPage(int type){
            var code = new groupRuleCode();
            ViewBag.ruleVal = ruleVal;
            ViewData["loginName"] = loginName;
            ViewBag.Auth = "Y";
            ViewBag.loginAccLV = loginAccLV;
            ViewBag.showDepartFilter = (ruleVal & code.allEmployeeList)>0? true : false;
            ViewBag.editPunchLog = (ruleVal & code.editPunchLog)>0? true : false;
            switch(type){
                case 1: ViewBag.Page = "punch"; break;
                case 2: ViewBag.Page = "leave"; break;
                case 3: ViewBag.Page = "leaveLog"; break;
                case 4: ViewBag.Page = "overtime"; break;
                case 5: ViewBag.Page = "overtimeLog"; break;
                default: ViewBag.Page = "noPage"; break;
            }   
            return View("ManagerSignPage");
        }

        public object getFilterOption(){
            var crossDepart = ((ruleVal & ruleCode.allEmployeeList) > 0)? true: false;
            return mRepository.GetDepartPosition((int)loginID, crossDepart);
        }


        //---------------------------------------------------------------------------------------
        
        #region punchWarn
        
        public object getPunchLogWarn(string fDepart){
            var code = new groupRuleCode();
            if((ruleVal & code.allEmployeeList) > 0){
                fDepart = String.IsNullOrEmpty(fDepart)? "" : fDepart;
                return Repository.GetPunchLogWarn_canAll((int)loginID, fDepart);
            }
            return Repository.GetPunchLogWarn((int)loginID);
        }

        public int ignorePunchLogWarn(int[] punchLogID){
            return Repository.IgnorePunchLogWarn(punchLogID);
        }

        

        #endregion //punchWarn
        
        //--------------------------------------------------------------------------------------------------------

        #region  LeaveOffice

        public object getEmployeeApplyLeave(string fDepart, int page, DateTime sDate, DateTime eDate){
            var code = new groupRuleCode();
            if((ruleVal & code.allEmployeeList) > 0){
                fDepart = String.IsNullOrEmpty(fDepart)? "" : fDepart;
                return Repository.GetEmployeeApplyLeave_canAll((int)loginID, fDepart, page, sDate, eDate);
            }
            return Repository.GetEmployeeApplyLeave((int)loginID, page, sDate, eDate);
        }

        public int isAgreeApplyLeave(int applyLeaveID, int isAgree){
            return Repository.IsAgreeApplyLeave(applyLeaveID, isAgree, (int)loginID);
        }

        #endregion //leaveOffice

        //--------------------------------------------------------------------------------------------------------

        #region  overtime

        public object getEmployeeApplyOvertime(string fDepart, int page, DateTime sDate, DateTime eDate){
            var code = new groupRuleCode();
            if((ruleVal & code.allEmployeeList) > 0){
                fDepart = String.IsNullOrEmpty(fDepart)? "" : fDepart;
                return Repository.GetEmployeeApplyOvertime_canAll((int)loginID, fDepart, page, sDate, eDate);
            }
            return Repository.GetEmployeeApplyOvertime((int)loginID, page, sDate, eDate);
        }

        public int isAgreeApplyOvertime(int applyLeaveID, int isAgree){
            return Repository.IsAgreeApplyOvertime(applyLeaveID, isAgree, (int)loginID);
        }

        #endregion //overtime

        
    }
}
