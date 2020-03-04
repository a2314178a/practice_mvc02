using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using practice_mvc02.Repositories;
using practice_mvc02.Models.dataTable;

namespace practice_mvc02.Models
{
    public class punchCardFunction
    {
        public PunchCardRepository Repository { get; }
        private ISession _session;
        private punchStatusCode psCode;
        private int? loginID;
        private int? loginDepartmentID;
        const int lessStHour = -2;
        const int addEtHour = 13;

        public punchCardFunction(PunchCardRepository repository, IHttpContextAccessor httpContextAccessor){
            this.Repository = repository;
            if(httpContextAccessor.HttpContext != null){
                this._session = httpContextAccessor.HttpContext.Session;
                this.loginID = _session.GetInt32("loginID");
                this.loginDepartmentID = _session.GetInt32("loginDepartmentID");
            }
            this.psCode = new punchStatusCode();
        }


        public int punchCardProcess(PunchCardLog logData, WorkTimeRule thisWorkTime, int action, int employeeID)
        {   
            object workTime = workTimeProcess(thisWorkTime);
            var sWorkDt = getObjectValue("sWorkDt", workTime);
            var eWorkDt = getObjectValue("eWorkDt", workTime);
            var sPunchDT = getObjectValue("sPunchDT", workTime);
            var workAllTime = getObjectValue("workAllTime", workTime);
            int resultCount = 0; //0:操作異常 1:成功 2:上班已打卡 3:現在時段不能打下班卡 4:不能補打上班時間
            var statusCode = 0;
            if(logData == null) //今日皆未打卡      //statusCode:  0x01:正常 0x02:遲到 0x04:早退 0x08:加班 0x10:缺卡 0x20:曠職
            {
                logData = new PunchCardLog();
                logData.accountID = employeeID;
                logData.departmentID = (int)loginDepartmentID;
                logData.logDate = sWorkDt.Date;
                logData.lastOperaAccID = (int)loginID;
                logData.createTime = DateTime.Now;
                if(action == 0){    //下班
                    if(DateTime.Now >= sPunchDT && DateTime.Now <= sWorkDt){
                        return 3;
                    }
                    logData.offlineTime = DateTime.Now;
                    statusCode = statusCode | psCode.hadLost;
                    statusCode = DateTime.Now < eWorkDt ? (statusCode | psCode.earlyOut) : statusCode;
                }else if(action == 1){  //上班
                    logData.onlineTime = DateTime.Now;
                    statusCode = DateTime.Now > sWorkDt ? (statusCode | psCode.lateIn) : statusCode;
                }else{
                    return 0;
                }    
                logData.punchStatus = workAllTime ? psCode.normal : statusCode;
                resultCount = DateTime.Now > eWorkDt && action == 1 ? 4 : Repository.AddPunchCardLog(logData);
                if(resultCount == 1 && logData.punchStatus > 1){    //一定要新增log成功 不然會沒logID
                    Repository.AddPunchLogWarnAndMessage(logData);
                }
            }
            else   //今日有打過卡 or 電腦生成(跨日才有可能遇到)
            {
                if(action == 0) //打下班卡
                {   
                    if(DateTime.Now >= sPunchDT && DateTime.Now <= sWorkDt && logData.onlineTime.Year == 1){
                        resultCount = 3;
                    }else{
                        statusCode = logData.punchStatus;
                        logData.offlineTime = DateTime.Now;
                        statusCode = logData.onlineTime.Year == 1? (statusCode | psCode.hadLost) : statusCode;
                        statusCode = DateTime.Now < eWorkDt ? (statusCode | psCode.earlyOut) : statusCode;  
                        logData.lastOperaAccID = (int)loginID;
                        logData.updateTime = DateTime.Now;
                        logData.punchStatus = workAllTime || statusCode ==0 ? psCode.normal : statusCode;
                        resultCount = Repository.UpdatePunchCard(logData);
                    }
                }
                else if(action == 1)  //打上班卡
                {  
                    if(logData.onlineTime.Year != 1){    //已打上班卡
                        resultCount = 2;
                    }else{  
                        statusCode = logData.punchStatus;
                        if(DateTime.Now >= eWorkDt || logData.offlineTime.Year !=1){
                            resultCount = 4;
                        }else{
                            logData.onlineTime = DateTime.Now;
                            statusCode = DateTime.Now > sWorkDt? (statusCode | psCode.lateIn) : statusCode;
                            logData.lastOperaAccID = (int)loginID;
                            logData.updateTime = DateTime.Now;
                            logData.punchStatus = workAllTime ? psCode.normal : statusCode;
                            resultCount = Repository.UpdatePunchCard(logData);
                        }
                    }
                }
                if(logData.punchStatus > 1){
                    Repository.AddPunchLogWarnAndMessage(logData);
                }
            }
            return resultCount;
        }

        public int forcePunchLogProcess(PunchCardLog processLog, WorkTimeRule thisWorkTime, string action, string from=""){
            object workTime = workTimeProcess(thisWorkTime, processLog);
            var sWorkDt = getObjectValue("sWorkDt", workTime);
            var eWorkDt = getObjectValue("eWorkDt", workTime);
            var sPunchDT = getObjectValue("sPunchDT", workTime);
            var ePunchDT = getObjectValue("ePunchDT", workTime);
            var workAllTime = getObjectValue("workAllTime", workTime);
            var statusCode = 0;     //statusCode:  0x01:正常 0x02:遲到 0x04:早退 0x08:加班 0x10:缺卡 0x20:曠職 
            processLog.lastOperaAccID = (int)loginID;
            if(action == "update"){
                processLog.updateTime = DateTime.Now;
            }else{
                processLog.createTime = DateTime.Now;
            }
            
            if(processLog.onlineTime.Year != 1 && processLog.offlineTime.Year != 1)//上下班時間皆有填寫
            {      
                processLog.logDate = sWorkDt.Date;
                if(processLog.onlineTime < sPunchDT){
                    processLog.onlineTime = processLog.onlineTime.AddDays(1);
                }
                if(processLog.onlineTime >= processLog.offlineTime){  
                    processLog.offlineTime = processLog.offlineTime.AddDays(1);   
                }
                statusCode = processLog.onlineTime > sWorkDt ? (statusCode | psCode.lateIn) : statusCode;
                statusCode = processLog.offlineTime < eWorkDt ? (statusCode | psCode.earlyOut) : statusCode;  
                processLog.punchStatus = statusCode == 0 ? psCode.normal : statusCode;  
            }
            else
            {  //上班或下班時間沒填
                if(processLog.onlineTime.Year !=1){    //填上班
                    statusCode = processLog.onlineTime > sWorkDt ? (statusCode | psCode.lateIn) : statusCode;
                    statusCode = DateTime.Now >= ePunchDT ? (statusCode | psCode.hadLost) : statusCode;   //打不到下班卡
                    if(processLog.onlineTime < sPunchDT){
                        processLog.onlineTime = processLog.onlineTime.AddDays(1);
                    }
                }else if(processLog.offlineTime.Year !=1){  //填下班
                    statusCode |= psCode.hadLost;
                    statusCode = processLog.offlineTime < eWorkDt ? (statusCode | psCode.earlyOut) : statusCode;
                }else{
                    statusCode = psCode.noWork;
                }
                processLog.punchStatus = statusCode;
                processLog.logDate = sWorkDt.Date;            
            }
            processLog.punchStatus = workAllTime ? psCode.normal : processLog.punchStatus;
            int result = action == "update"? Repository.UpdatePunchCard(processLog) : Repository.AddPunchCardLog(processLog);
            if(result == 1 && processLog.punchStatus > 1){
                Repository.AddPunchLogWarnAndMessage(processLog);
            }
            if(action == "update" && from == "applySign" && result==1){
                Repository.UpdatePunchLogWarn(processLog.ID);
            }
            return result;
        }
        
        public object workTimeProcess(WorkTimeRule thisWorkTime, PunchCardLog customLog = null){
            DateTime sWorkDt = DateTime.Now.Date;  //online work dateTime
            DateTime eWorkDt = DateTime.Now.Date;   //offline work dateTime
            DateTime sPunchDT = DateTime.Now.Date;  //可打卡時間
            DateTime ePunchDT = DateTime.Now.Date;  //
            if(customLog != null){
                if(customLog.onlineTime.Year !=1){
                    sWorkDt = eWorkDt = sPunchDT = ePunchDT = customLog.onlineTime.Date;
                }else if(customLog.offlineTime.Year !=1){
                    sWorkDt = eWorkDt = sPunchDT = ePunchDT = customLog.offlineTime.Date;
                }else if(customLog.logDate.Year !=1){
                    sWorkDt = eWorkDt = sPunchDT = ePunchDT = customLog.logDate.Date;
                }
            }
            bool workAllTime = false;                                
            if(thisWorkTime != null)
            { 
                sWorkDt = sWorkDt + thisWorkTime.startTime;  
                eWorkDt = eWorkDt + thisWorkTime.endTime; 
                eWorkDt = eWorkDt <= sWorkDt ? eWorkDt.AddDays(1) : eWorkDt;  
                sPunchDT = sWorkDt.AddHours(lessStHour);
                ePunchDT = eWorkDt.AddHours(addEtHour);
                if(customLog == null){
                    if(DateTime.Now >= ePunchDT){
                        sPunchDT = sPunchDT.AddDays(1);
                        ePunchDT = ePunchDT.AddDays(1);
                        sWorkDt = sPunchDT.AddHours((lessStHour*-1));
                        eWorkDt = sPunchDT.AddHours((addEtHour*-1));
                    }else if(DateTime.Now < sPunchDT){
                        sPunchDT = sPunchDT.AddDays(-1);   
                        ePunchDT = ePunchDT.AddDays(-1);
                        sWorkDt = sPunchDT.AddHours((lessStHour*-1));
                        eWorkDt = sPunchDT.AddHours((addEtHour*-1));   
                    }
                }  
            }else{
                workAllTime = true;
                eWorkDt = eWorkDt.AddDays(1);
                ePunchDT = ePunchDT.AddDays(1);
            }
            return new{
                sWorkDt=sWorkDt, eWorkDt=eWorkDt, 
                sPunchDT=sPunchDT, ePunchDT=ePunchDT, 
                workAllTime=workAllTime
            };
        }

        public dynamic getObjectValue(string key, object obj){
            return obj.GetType().GetProperty(key).GetValue(obj);
        }

        public void processPunchlogWarn(PunchCardLog log, WorkTimeRule thisWorkTime){
            object workTime = workTimeProcess(thisWorkTime, log);
            var sWorkDt = getObjectValue("sWorkDt", workTime);
            var eWorkDt = getObjectValue("eWorkDt", workTime);
            var sPunchDT = getObjectValue("sPunchDT", workTime);
            var ePunchDT = getObjectValue("ePunchDT", workTime);
            var workAllTime = getObjectValue("workAllTime", workTime);
            var statusCode = log.punchStatus;     //statusCode:  0x01:正常 0x02:遲到 0x04:早退 0x08:加班 0x10:缺卡 0x20:曠職

            if(DateTime.Now < ePunchDT){
                return;
            }
            if(log.onlineTime.Year == 1 && log.offlineTime.Year == 1){
                statusCode = psCode.noWork;
            }else{
                if(log.offlineTime.Year == 1){ 
                statusCode = DateTime.Now >= ePunchDT ? (statusCode | psCode.hadLost) : statusCode; 
                }else{ 
                    statusCode = log.offlineTime < eWorkDt ? (statusCode | psCode.earlyOut) :statusCode;
                }
                if(log.onlineTime.Year == 1){
                    statusCode = DateTime.Now >= eWorkDt ? (statusCode | psCode.hadLost) : statusCode; 
                }else{
                    statusCode = log.onlineTime > sWorkDt ? (statusCode | psCode.lateIn) : statusCode; 
                }
                if(log.onlineTime.Year != 1 && log.offlineTime.Year != 1 && statusCode == 0){
                    statusCode = psCode.normal;
                }
            }
            log.punchStatus = statusCode;
            Repository.UpdatePunchCard(log);
            Repository.AddPunchLogWarnAndMessage(log);
        }
        
    }
}