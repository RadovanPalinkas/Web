using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
//1) naformátuje odsazení pro data v Jsonu
//2) naformátuje velká počáteční písmena elementů na malá, pro "Json"
//3) nakonfiguruje api tak aby vraceli pouze data v Json formátu, tím že odstraní XmlFormatter
//4) pokud bude v hlavičce requestu accept: "text/html" tak místo xml vrátí Json
//   a v hlavičce odpovědi uvede Jsou místo "text/html".
namespace WebovaAplikace
{
    public static class WebApiConfig
    {
        
        public static void Register(HttpConfiguration config)
        {
            // Služby a konfigurace rozhraní Web API

            // Trasy rozhraní Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "Api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            //**1**
            //config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            //**2**
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //**3**
            //config.Formatters.Remove(config.Formatters.XmlFormatter);
            //**4**
            config.Formatters.Add(new CustomJsonFormater());
            
        }
        //**4**
        public class CustomJsonFormater : JsonMediaTypeFormatter
        {
            public CustomJsonFormater()
            {
                this.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
            }
            public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
            {
                base.SetDefaultContentHeaders(type, headers, mediaType);
                headers.ContentType = new MediaTypeHeaderValue("application/json");
            }
        }
    }
}
