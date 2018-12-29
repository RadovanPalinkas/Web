using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace WebovaAplikace.Common.Filters
{
    public class UnavailableServiceFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is EntityException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.ServiceUnavailable, "Nepodařilo se připojit k databázi");
            }
            if (actionExecutedContext.Exception is ArgumentNullException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.BadRequest, "Neplatný požadavek");
            }
        }
    }

}