using System;
using Bold.WebAPI.Commons.Helpers;
using Bold.WebAPI.Data.SalesItems;
using Bold.WebAPI.Data.Transformers;


namespace Bold.WebAPI.Data.Products
{
    public class ProductDataManager : IProductDataManger
    {
        private readonly ISalesItemsManager _manager;
        private readonly LanguageHelper _languageHelper;
        public ProductDataManager() : this(new SalesItemManager()) {}

        public ProductDataManager(ISalesItemsManager manager)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(manager));
            _languageHelper = new LanguageHelper();
        }

        public Model.Product.Product GetProduct(string productId, string locale)
        {
            var data = _manager.GetSalesItemByProductId(productId);
            var langId = _languageHelper.GetLanguageId(locale);
            var info = _manager.GetProductInfo(data.Item1.SalesItemsId, langId);
            var resourceDtos = _manager.GetResourcePicturesInfoBySalesItemId(data.Item1.SalesItemsId);
            var product = ProductTransformer.CreateProductFromBoldData(data, info, resourceDtos);
            return product;
        }
    }
}
