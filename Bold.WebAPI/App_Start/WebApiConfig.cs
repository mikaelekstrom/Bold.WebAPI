using System.Web.Http;
using System.Web.Http.Routing;
using Bold.WebAPI.Helpers;
using Microsoft.Web.Http.Routing;
using Newtonsoft.Json.Serialization;

namespace Bold.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var constraintResolver = new DefaultInlineConstraintResolver
            {
                ConstraintMap =
                {
                    ["apiVersion"] = typeof(ApiVersionRouteConstraint)
                }
            };

            GlobalConfiguration.Configure(s => 
                s.MapHttpAttributeRoutes(constraintResolver, new GlobalPrefixProvider("api/v{version:apiVersion}")));

            config.AddApiVersioning();

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
