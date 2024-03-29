﻿using AuthApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AuthApi.CustomAttribute
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        private AuthService AuthService { get; set; }
        public BasicAuthenticationAttribute()
        {
            AuthService = new AuthService();
        }
        //public override void OnAuthorization(HttpActionContext actionContext)
        //{
        //    base.OnAuthorization(actionContext);
        //}
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization != null)
            {
                var authToken = actionContext.Request.Headers
                    .Authorization.Parameter;

                // decoding authToken we get decode value in 'Username:Password' format  
                var decodeauthToken = System.Text.Encoding.UTF8.GetString(
                    Convert.FromBase64String(authToken));

                // spliting decodeauthToken using ':'   
                var arrUserNameandPassword = decodeauthToken.Split(':');

                // at 0th postion of array we get username and at 1st we get password  
                if (AuthService.IsAuthorizedUser(arrUserNameandPassword[0], arrUserNameandPassword[1]))
                {
                    // setting current principle  
                    Thread.CurrentPrincipal = new GenericPrincipal(
                           new GenericIdentity(arrUserNameandPassword[0]), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request
                        .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            else
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
            }
        }
        //public static bool IsAuthorizedUser(string Username, string Password)
        //{
        //    // In this method we can handle our database logic here...
        //    //Base64Value: Um9ja3k6UGFzczE=
        //    return Username == "Rocky" && Password == "Pass1";
        //}
    }

    //****************jquery code to consume the api************************
 //   <script type = "text/javascript" >
 //       $.ajax({
 //   type: 'GET',  
 //           url: "api/values/Get",  
 //           datatype: 'json',  
 //           headers:
 //       {
 //       Authorization: 'Basic ' + btoa(username + ':' + password)
 //               },  
 //           success: function(data) {
 //       },  
 //           error: function(data) {
 //       }
 //   });          
 //</script> 
}