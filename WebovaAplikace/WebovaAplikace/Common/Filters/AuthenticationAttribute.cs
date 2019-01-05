﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebovaAplikace.Common.Authentication.Implementations;

namespace WebovaAplikace.Common.Filters
{
    
    
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {       
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] emailPasswordArray = decodedAuthenticationToken.Split(':');
                string email = emailPasswordArray[0];
                string password = emailPasswordArray[1];
                
                if (EmployeeSecurity.Login(email, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(email), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request
                   .CreateResponse(HttpStatusCode.Unauthorized);
                }

            }
            
        }
    }
}