using Bold.WebAPI.Model.StoreConfiguration;

namespace Bold.WebAPI.Data.StoreConfigurations
{
    public interface IStoreConfigurationsManager
    {
        StoreConfiguration GetStoreConfigurationById(int configurationId);
    }
}
