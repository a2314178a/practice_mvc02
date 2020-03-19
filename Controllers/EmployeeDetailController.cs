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
    public class EmployeeDetailController : BaseController
    {
        public MasterRepository Repository { get; }
        public loginFunction loginFn {get;}

        public EmployeeDetailController(MasterRepository repository, IHttpContextAccessor httpContextAccessor):base(httpContextAccessor)
        {
            this.Repository = repository;
            this.loginFn = new loginFunction(repository);
        }

        public IActionResult Index()
        {           
            return selectPage();
            //return RedirectToAction("logOut", "Home"); //轉址到特定Controller的ACTION名字
        }

        public IActionResult selectPage(){
            ViewBag.ruleVal = ruleVal;
            ViewData["loginName"] = loginName;
            ViewBag.Auth = "Y";
            ViewBag.loginAccLV = loginAccLV;
            return View("EmployeeDetailPage");
        }
        //---------------------------------------------------------------------------------------
        
        public object getMyDetail(){
            return Repository.GetAccountDetail((int)loginID);
        }

        public object getSelOption(){
            return Repository.GetAllPrincipal();
        }

        public int updateMyDetail(MyDetail data){
            if(data.password != null){
                data.password = loginFn.GetMD5((loginAcc + data.password));
            }
            return Repository.UpdateMyDetail((int)loginID, data);
        }
        
    }
}
