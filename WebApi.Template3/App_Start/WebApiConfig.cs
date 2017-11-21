using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApi.Template3.App_Start
{
    public class WebApiConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}