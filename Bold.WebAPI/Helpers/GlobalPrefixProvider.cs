using System.Web.Http.Controllers;
using System.Web.Http.Routing;

namespace Bold.WebAPI.Helpers
{
    public class GlobalPrefixProvider : DefaultDirectRouteProvider
    {
        private readonly string _globalPrefix;

        public GlobalPrefixProvider(string globalPrefix)
        {
            this._globalPrefix = globalPrefix;
        }

        protected override string GetRoutePrefix(HttpControllerDescriptor controllerDescriptor)
        {
            var existingPrefix = base.GetRoutePrefix(controllerDescriptor);

            return existingPrefix == null ? _globalPrefix : $"{_globalPrefix}/{existingPrefix}";
        }
    }
}