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
    public class SetRuleController : BaseController
    {
        //private readonly ILogger<HomeController> _logger;
        public SetRuleRepository Repository { get; }
        public loginFunction loginFn {get;}

        public SetRuleController(SetRuleRepository repository, IHttpContextAccessor httpContextAccessor):base(httpContextAccessor)
        {
            this.Repository = repository;
            this.loginFn = new loginFunction(repository);
        }

        public IActionResult Index(string page)
        {           
            if(loginFn.isLoginInfo(loginID, loginAccLV) && (ruleVal & ruleCode.setRule) > 0){
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
            ViewBag.Page = page;
            return View("SetRulePage");
        }

       //--------------------------------------------------------------------------------------

        #region timeRule
        public object getAllTimeRule(){
           return Repository.GetAllTimeRule();
       }

        public int addTimeRule(WorkTimeRule newRule){
            if(!loginFn.chkCurrentUser(loginID, loginTimeStamp)){
                return -2;
            }
            newRule.lastOperaAccID = (int)loginID;
            newRule.createTime = DateTime.Now;
            return Repository.AddTimeRule(newRule);
        }

        public int delTimeRule(int timeRuleID){
            if(!loginFn.chkCurrentUser(loginID, loginTimeStamp)){
                return -2;
            }
            return Repository.DelTimeRule(timeRuleID);
        }

        public int updateTimeRule(WorkTimeRule updateData){
            if(!loginFn.chkCurrentUser(loginID, loginTimeStamp)){
                return -2;
            }
            updateData.lastOperaAccID = (int)loginID;
            updateData.updateTime = DateTime.Now;
            return Repository.UpdateTimeRule(updateData);
        }
        #endregion //timeRule
        
        //-----------------------------------------------------------------------------------------------------

        #region GroupRule
        public object getAllGroup(){
            return Repository.GetAllGroup();
        }

        public int addGroup(GroupRule newGroup){
            if(!loginFn.chkCurrentUser(loginID, loginTimeStamp)){
                return -2;
            }
            newGroup.lastOperaAccID = (int)loginID;
            newGroup.createTime = DateTime.Now;
            return Repository.AddGroup(newGroup);
        }

        public int delGroup(int groupID){
            if(!loginFn.chkCurrentUser(loginID, loginTimeStamp)){
                return -2;
            }
            return Repository.DelGroup(groupID);
        }

        public int updateGroup(GroupRule updateGroup){
            if(!loginFn.chkCurrentUser(loginID, loginTimeStamp)){
                return -2;
            }
            updateGroup.lastOperaAccID = (int)loginID;
            updateGroup.updateTime = DateTime.Now;
            return Repository.UpdateGroup(updateGroup);
        }

        #endregion  //GroupRule

        //-----------------------------------------------------------------------------------------------------

        #region specialDate
        
        public object getAllSpecialDate(){
            return Repository.GetAllSpecialDate();
        }

        public int addUpSpecialTime(SpecialDate spDate){
            if(!loginFn.chkCurrentUser(loginID, loginTimeStamp) || (ruleVal & ruleCode.setRule)==0){
                return -2;
            }
            spDate.lastOperaAccID = (int)loginID;
            if(spDate.ID == 0){     
                spDate.createTime = DateTime.Now;
                return Repository.AddSpecialTime(spDate);
            }else{
                spDate.updateTime = DateTime.Now;
                return Repository.UpdateSpecialTime(spDate);
            } 
        }

        public int delSpecialDate(int spDateID){
            if(!loginFn.chkCurrentUser(loginID, loginTimeStamp) || (ruleVal & ruleCode.setRule)==0){
                return -2;
            }
            return Repository.DelSpecialDate(spDateID);
        }

        #endregion //specialDate


        
    }
}
