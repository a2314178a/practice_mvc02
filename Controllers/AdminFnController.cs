﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
    public class AdminFnController : BaseController
    {
        public AdminFnRepository aRepository { get; }
        public MasterRepository mRepository { get; }
        public PunchCardRepository pRepository { get; }
        private ChkPunchLogWarn chkWarn { get; }
        private CalWorkTime calTime { get; }
        private CalAnnualLeave calAnnual { get; }
        
        public AdminFnController(AdminFnRepository a_repository, MasterRepository m_repository,
                                PunchCardRepository p_repository, AnnualLeaveRepository al_repository,
                                ApplyOvertimeRepository ap_repository, 
                                IHttpContextAccessor httpContextAccessor):base(httpContextAccessor)                
        {
            this.aRepository = a_repository;
            this.mRepository = m_repository;
            this.pRepository = p_repository;
            this.chkWarn = new ChkPunchLogWarn(p_repository, httpContextAccessor);
            this.calTime = new CalWorkTime(p_repository, ap_repository, httpContextAccessor);
            this.calAnnual = new CalAnnualLeave(al_repository);
        }

        public IActionResult Index(string page="operateLog")
        {           
            return selectPage(page);
        }

        public IActionResult selectPage(string page){
            ViewBag.ruleVal = ruleVal;
            ViewBag.Auth = "Y";
            ViewBag.ID = (int)loginID;
            ViewBag.loginAccLV = loginAccLV;
            ViewBag.Page = page;
            return View("AdminFnPage");
        }

        public List<ViewOpLog> getOperateLog(OpLogFilter filter){
            filter.eDate = filter.eDate.AddDays(1);
            filter.active = String.IsNullOrEmpty(filter.active)? "" : filter.active;
            filter.category = String.IsNullOrEmpty(filter.category)? "" : filter.category;
            return aRepository.GetOperateLog(filter);
        }

        public object getFilterOption(){
            var category = aRepository.GetOpLogCategory();
            var userName = mRepository.GetAllPrincipal();
            return new {category, userName};
        }

        public void manual_refreshPunchLogWarn(){
            if(((int)ruleVal & new groupRuleCode().adminFn) >0){
                chkWarn.start();
            }
        }

        public void manual_calWorkTime(int month=0){  //month:正整數 減幾個月 預設0
            if(((int)ruleVal & new groupRuleCode().adminFn) >0){
                calTime.start(month);
            }
        }

        public void manual_calAnnualLeave(){
            if(((int)ruleVal & new groupRuleCode().adminFn) >0){
                calAnnual.start();
            }
        }

        /*public void clearEmployeeAnnualLeaves(int month=36){   //清除舊的年假 以deadline做為判斷
            var dt = definePara.dtNow().Date;
            dt = dt.AddMonths(-month);
            aRepository.ClearEmployeeAnnualLeaves(dt);  
        }

        public void clearEmployeeLeaveOfficeApply(int month=36){    //清除舊請假紀錄 以createTime為判斷
            var dt = definePara.dtNow().Date;
            dt = dt.AddMonths(-month);
            aRepository.ClearEmployeeLeaveOfficeApply(dt);
        }

        public void clearMessageAndMsgSendReceive(){ //清除訊息 需寄件人與收件人都刪除才可清除
            aRepository.ClearMessageAndMsgSendReceive();
        }

        public void clearOperateLogs(int month=60){ //清除操作紀錄 以createTime為判斷
            var dt = definePara.dtNow().Date;
            dt = dt.AddMonths(-month);
            aRepository.ClearOperateLogs(dt);
        }

        public void clearPunchCardLogs(int month=36){   //清除打卡 以logDate為判斷
            var dt = definePara.dtNow().Date;
            dt = dt.AddMonths(-month);
            aRepository.ClearPunchCardLogs(dt);
        }

        public void clearPunchLogWarns(){   //清除打卡異常紀錄 以punchLogID是否存在進行判斷
            aRepository.ClearPunchLogWarns();
        }*/
    }

}
