using System.Web.Http;

namespace CodeCamper.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "ApiControllerOnly",
                routeTemplate: "api/{controller}"
            );

            config.Routes.MapHttpRoute(
                name: "ApiControllerAndId",
                routeTemplate: "api/{controller}/{id}",
                defaults: null,
                constraints: new { id = @"^\d+$" }
            );

            config.Routes.MapHttpRoute(
                name: "ApiControllerAction",
                routeTemplate: "api/{controller}/{action}"
            );
        }
    }
}
