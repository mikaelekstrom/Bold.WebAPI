using System;
using System.Web.Http;
using System.Web.Script.Serialization;
using Bold.WebAPI.Commons.Constants;
using Bold.WebAPI.Data.StoreConfigurations;
using Microsoft.Web.Http;

namespace Bold.WebAPI.Controllers
{
    [ApiVersion("1")]
    [RoutePrefix(Constants.RoutePrefixes.StoreConfiguration)]
    public class StoreConfigurationController : ApiController
    {
        private readonly IStoreConfigurationsManager _configurationsManager;
        public StoreConfigurationController() : this(new StoreConfigurationsManager()) {}
        public StoreConfigurationController(IStoreConfigurationsManager configurationsManager)
        {
            _configurationsManager = configurationsManager ?? throw new ArgumentNullException(nameof(configurationsManager));
        }

        [Route("{configurationId}")]
        public string GetStoreConfiguration(int configurationId)
        {
            var configuration = _configurationsManager.GetStoreConfigurationById(configurationId);
            return new JavaScriptSerializer().Serialize(configuration);
        }
    }
}
