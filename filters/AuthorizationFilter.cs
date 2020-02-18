using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using practice_mvc02.Repositories;

namespace practice_mvc02.filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        //AccountRepository  Repository;
        private int? loginID;
        private int? loginAccLV;
        private string loginTimeStamp;
        private ISession _session;

        /*public AuthorizationFilter(AccountRepository repository){
            this.Repository = repository;
        }*/

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            this._session = context.HttpContext.Session;
            this.loginID = _session.GetInt32("loginID");
            this.loginAccLV = _session.GetInt32("loginAccLV");
            this.loginTimeStamp = _session.GetString("loginTimeStamp");


            /*if(!chkCurrentUser(loginID, loginTimeStamp)){
                return -2;
            }*/
        }


        /*private bool chkCurrentUser(int? loginID, string loginTimeStamp){
            string getTimeStamp = Repository.QueryTimeStamp(loginID);
            if(loginTimeStamp == getTimeStamp){
                return true;
            }else{
                return false;
            }
        }*/

        

        

    }

    
}


