using System;
using Bold.WebAPI.Commons.Helpers;
using Bold.WebAPI.Model.StoreConfiguration;
using Dacsa.Framework.Shared.Interfaces;

namespace Bold.WebAPI.Data.StoreConfigurations
{
    public class StoreConfigurationsManager : IStoreConfigurationsManager
    {
        private readonly IServer _server;

        public StoreConfigurationsManager() : this(ServiceHelper.GetIServerServiceWrapper()) {}
        public StoreConfigurationsManager(IServer server)
        {
            _server = server ?? throw new ArgumentNullException(nameof(server));
        }

        public StoreConfiguration GetStoreConfigurationById(int storeConfigurationId)
        {
            var config = _server.GetStoreViewConfigurationDTO(storeConfigurationId);
            return new StoreConfiguration(config);
        }
    }
}
