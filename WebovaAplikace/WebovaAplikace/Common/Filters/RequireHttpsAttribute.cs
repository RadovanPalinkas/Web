using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
//filtr který automaticky převede http komunikaci na https komunikaci
//1)Do těla meziodpovědi vloží takq a v hlavičce změní MediaType
namespace WebovaAplikace.Common.Filters
{
    public class RequireHttpsFilterAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Found);
                //**1**
                actionContext.Response.Content = new StringContent("<p>Use Https insted Http</p>", Encoding.UTF8, "text/html");

                string[] segmentUri = actionContext.Request.RequestUri.Segments;
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < 3 ; i++)
                {
                    stringBuilder.Append( segmentUri[i]);
                }

                UriBuilder uriBuilder = new UriBuilder(actionContext.Request.RequestUri);
                uriBuilder.Path = stringBuilder.ToString();
                uriBuilder.Scheme = Uri.UriSchemeHttps;
                uriBuilder.Port = 44357;
                uriBuilder.Query = null;
                actionContext.Response.Headers.Location = uriBuilder.Uri;
             
            }
            else
            {
                base.OnAuthorization(actionContext);
            }

        }
    }
}