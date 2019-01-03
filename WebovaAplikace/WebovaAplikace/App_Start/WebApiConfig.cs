using System;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using WebovaAplikace.Common.Filters;

//1) naformátuje odsazení pro data v Jsonu
//2) naformátuje velká počáteční písmena elementů na malá, pro "Json"
//3) nakonfiguruje api tak aby vraceli pouze data v Json formátu, tím že odstraní XmlFormatter
//4) pokud bude v hlavičce requestu accept: "text/html" tak místo xml vrátí Json
//   a v hlavičce odpovědi uvede Json místo "text/html".
//5) nastaví CORS pro všechný všechnz domány, všechny tyty hlaviček a všechny matody např GET,POST.
//   Cors umožňuje posílat ajax požadavky na různé domény
//6) nastavý outomatické přesměrování na HTTPS
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
            //**5**
            config.EnableCors();
            //**6**
            config.Filters.Add(new RequireHttpsFilterAttribute());
            config.Filters.Add(new UnavailableServiceFilterAttribute());
           
          
        }
    }
    //**4**
    public class CustomJsonFormater : JsonMediaTypeFormatter
    {
        public CustomJsonFormater()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);

            headers.ContentType = new MediaTypeHeaderValue("application/json");

        }
    }
}
