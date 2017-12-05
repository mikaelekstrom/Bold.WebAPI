using System;
using Bold.WebAPI.Commons.Helpers;
using Dacsa.Data.Entities.DTO.StoreConfiguration;

namespace Bold.WebAPI.Model.StoreConfiguration
{
    public class StoreConfiguration
    {
        public readonly int ConfigurationId;
        public readonly int StoreId;
        public readonly int CountryId;
        public readonly string Locale;
        public readonly int PriceListId;
        public readonly int GroupTreeId;
        public readonly int RootNodeId;

        public StoreConfiguration(StoreViewConfigurationDTO configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));
            ConfigurationId = configuration.Id;
            CountryId = configuration.CountryId;
            StoreId = configuration.MagentoStoreConfiguration.StoreId;
            GroupTreeId = configuration.MagentoStoreConfiguration.GroupTreeId;
            PriceListId = configuration.MagentoStoreConfiguration.SalesPriceListId;
            RootNodeId = configuration.MagentoStoreConfiguration.GroupTreeRootNodeId;
            Locale = new LanguageHelper().GetLanguageLocale(configuration.LanguageId);
        }
    }
}
