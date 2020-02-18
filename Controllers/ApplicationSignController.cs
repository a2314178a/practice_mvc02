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

        public IActionResult selectPage(int type=1){
            ViewBag.ruleVal = ruleVal;
            ViewData["loginName"] = loginName;
            ViewBag.Auth = "Y";
            ViewBag.loginAccLV = loginAccLV;
            switch(type){
                case 1: return View("PunchWarnPage");
                case 2: return View("TakeRestSignPage");
                case 3: return View("OutsideSignPage");
                default: return RedirectToAction("logOut", "Home");
            }   
        }

        //---------------------------------------------------------------------------------------
        
        

        
    }
}
