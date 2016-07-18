using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using chsakell_SPA.Infrastructure.MessageHandlers;

namespace chsakell_SPA
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MessageHandlers.Add(new HomeCinemaAuthHandler());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
