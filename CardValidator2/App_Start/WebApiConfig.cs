using System.Web.Http;

namespace CardValidator2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{cardNumber}",
                defaults: new { cardNumber = RouteParameter.Optional }
            );
        }
    }
}
