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
            this._session = httpContextAccessor.HttpContext.Session;
            this.loginID = _session.GetInt32("loginID");
            this.loginDepartmentID = _session.GetInt32("loginDepartmentID");
            this.psCode = new punchStatusCode();
        }


        public int punchCardProcess(PunchCardLog logData, WorkTimeRule thisWorkTime, int action, int employeeID)
        {   
            object workTime = workTimeProcess(thisWorkTime);
            var sWorkDt = getObjectValue("sWorkDt", workTime);
            var eWorkDt = getObjectValue("eWorkDt", workTime);
            var sPunchDT = getObjectValue("sPunchDT", workTime);
            var workAllTime = getObjectValue("workAllTime", workTime);
            int resultCount = 0; //0:操作異常 1:成功 2:上班已打卡 3:下班已打卡 4:不能補打上班時間
            var statusCode = 0;
            if(logData == null) //今日皆未打卡      //statusCode:  0x01:正常 0x02:遲到 0x04:早退 0x08:加班 0x10:缺卡 
            {
                logData = new PunchCardLog();
                logData.accountID = employeeID;
                logData.departmentID = (int)loginDepartmentID;
                logData.logDate = sWorkDt.Date;
                logData.lastOperaAccID = (int)loginID;
                logData.createTime = DateTime.Now;
                if(action == 0){    //下班
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
            }
            else   //今日有打過卡
            {
                if(action == 0) //打下班卡
                {   
                    statusCode = logData.punchStatus;
                    logData.offlineTime = DateTime.Now;
                    statusCode = DateTime.Now < eWorkDt ? (statusCode | psCode.earlyOut) : statusCode;  
                    logData.lastOperaAccID = (int)loginID;
                    logData.updateTime = DateTime.Now;
                    logData.punchStatus = workAllTime ? psCode.normal : statusCode == 0 ? psCode.normal : statusCode;
                    resultCount = Repository.UpdatePunchCard(logData);               
                }
                else if(action == 1)  //打上班卡
                {  
                    if(logData.onlineTime.Year != 1){    //已打上班卡
                        resultCount = 2;
                    }else{  //有打下班紀錄 (不然不會有logData)
                        resultCount = 4;
                    }
                }
            }
            return resultCount;
        }

        public int forcePunchLogProcess(PunchCardLog processLog, WorkTimeRule thisWorkTime, string action){
            object workTime = workTimeProcess(thisWorkTime, processLog);
            var sWorkDt = getObjectValue("sWorkDt", workTime);
            var eWorkDt = getObjectValue("eWorkDt", workTime);
            var sPunchDT = getObjectValue("sPunchDT", workTime);
            var ePunchDT = getObjectValue("ePunchDT", workTime);
            var workAllTime = getObjectValue("workAllTime", workTime);
            var statusCode = 0;     //statusCode:  0x01:正常 0x02:遲到 0x04:早退 0x08:加班 0x10:缺卡 
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
                }else{  //填下班
                    statusCode |= psCode.hadLost;
                    statusCode = processLog.offlineTime < eWorkDt ? (statusCode | psCode.earlyOut) : statusCode;
                }
                processLog.punchStatus = statusCode;
                processLog.logDate = sWorkDt.Date;            
            }
            processLog.punchStatus = workAllTime ? psCode.normal : processLog.punchStatus;
            return action == "update"? Repository.UpdatePunchCard(processLog) : Repository.AddPunchCardLog(processLog);
        }
        
        
        
        /*public int forceAddPunchCardProcess(PunchCardLog newPunchLog, WorkTimeRule thisWorkTime){
            object workTime = workTimeProcess(thisWorkTime, newPunchLog);
            var sWorkDt = getObjectValue("sWorkDt", workTime);
            var eWorkDt = getObjectValue("eWorkDt", workTime);
            var sPunchDT = getObjectValue("sPunchDT", workTime);
            var ePunchDT = getObjectValue("ePunchDT", workTime);
            int resultCode = 0;     //0:操作異常 1:成功 

            newPunchLog.lastOperaAccID = (int)loginID;
            newPunchLog.createTime = DateTime.Now;
            if(newPunchLog.onlineTime.Year != 1 && newPunchLog.offlineTime.Year != 1)//上下班時間皆有填寫
            {  
                newPunchLog.punchStatus = 1;    //punchStatus=  0:? 1:正常 2:缺卡 3:遲到 4:早退 5:加班
                newPunchLog.logDate = newPunchLog.onlineTime.Date;
                if(newPunchLog.onlineTime < sPunchDT){
                    newPunchLog.onlineTime = newPunchLog.onlineTime.AddDays(1);
                }
                if(newPunchLog.onlineTime >= newPunchLog.offlineTime){  
                    newPunchLog.offlineTime = newPunchLog.offlineTime.AddDays(1);   
                }
                if(newPunchLog.onlineTime > sWorkDt){
                    newPunchLog.punchStatus = 3;
                }else if(newPunchLog.offlineTime < eWorkDt){
                    newPunchLog.punchStatus = 4;
                }
                resultCode = Repository.AddPunchCardLog(newPunchLog);
            }
            else
            {  //上班或下班時間沒填
                if(newPunchLog.onlineTime.Year !=1){    //填上班
                    newPunchLog.logDate = newPunchLog.onlineTime.Date;
                    newPunchLog.punchStatus = 0;
                    if(newPunchLog.onlineTime > sWorkDt){
                        newPunchLog.punchStatus = 3;
                    }
                    else if(DateTime.Now >= ePunchDT){
                        newPunchLog.punchStatus = 2;
                    }
                }else{  //填下班
                    newPunchLog.punchStatus = newPunchLog.offlineTime < eWorkDt ? 4 : 2;
                    newPunchLog.logDate = newPunchLog.offlineTime.Date;
                    if(sWorkDt.Date != eWorkDt.Date){
                        newPunchLog.logDate = newPunchLog.logDate.AddDays(-1);
                    }
                }
                resultCode = Repository.AddPunchCardLog(newPunchLog);
            }
            return resultCode;
        }

        public int forceUpdatePunchCardProcess(PunchCardLog updatePunchLog, WorkTimeRule thisWorkTime){
            object workTime = workTimeProcess(thisWorkTime, updatePunchLog);
            var sWorkDt = getObjectValue("sWorkDt", workTime);
            var eWorkDt = getObjectValue("eWorkDt", workTime);
            var sPunchDT = getObjectValue("sPunchDT", workTime);
            var ePunchDT = getObjectValue("ePunchDT", workTime);
            int resultCode = 0;     //0:操作異常 1:成功 

            updatePunchLog.lastOperaAccID = (int)loginID;
            updatePunchLog.updateTime = DateTime.Now;
            if(updatePunchLog.onlineTime.Year != 1 && updatePunchLog.offlineTime.Year != 1)//上下班時間皆有填寫
            {  
                updatePunchLog.punchStatus = 1;    //punchStatus=  0:? 1:正常 2:缺卡 3:遲到 4:早退 5:加班
                updatePunchLog.logDate = updatePunchLog.onlineTime.Date;
                if(updatePunchLog.onlineTime < sPunchDT){
                    updatePunchLog.onlineTime = updatePunchLog.onlineTime.AddDays(1);
                }
                if(updatePunchLog.onlineTime >= updatePunchLog.offlineTime){  
                    updatePunchLog.offlineTime = updatePunchLog.offlineTime.AddDays(1);   
                }             
                if(updatePunchLog.onlineTime > sWorkDt){
                    updatePunchLog.punchStatus = 3;
                }else if(updatePunchLog.offlineTime < eWorkDt){
                    updatePunchLog.punchStatus = 4;
                }
                resultCode = Repository.UpdatePunchCard(updatePunchLog);
            }
            else
            {  //上班或下班時間沒填
                if(updatePunchLog.onlineTime.Year !=1){    //填上班
                    updatePunchLog.logDate = updatePunchLog.onlineTime.Date;
                    updatePunchLog.punchStatus = 0;
                    if(updatePunchLog.onlineTime > sWorkDt){
                        updatePunchLog.punchStatus = 3;
                    }else if(DateTime.Now >= ePunchDT){
                        updatePunchLog.punchStatus = 2;
                    }
                }else{  //填下班
                    updatePunchLog.punchStatus = updatePunchLog.offlineTime < eWorkDt ? 4 : 2;
                    updatePunchLog.logDate = updatePunchLog.offlineTime.Date;
                    if(sWorkDt.Date != eWorkDt.Date){
                        updatePunchLog.logDate = updatePunchLog.logDate.AddDays(-1);
                    }
                }
                resultCode = Repository.UpdatePunchCard(updatePunchLog);
            }
            return resultCode;
        }*/

        
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

        
        
    }
}