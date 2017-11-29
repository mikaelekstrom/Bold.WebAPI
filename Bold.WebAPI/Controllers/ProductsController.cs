using Microsoft.Web.Http;
using System;
using System.Web.Http;
using System.Web.Script.Serialization;
using Bold.WebAPI.Commons.Constants;
using Bold.WebAPI.Data.Products;

namespace Bold.WebAPI.Controllers
{
    [ApiVersion("1")]
    [RoutePrefix(Constants.RoutePrefixes.ProductsPrefix)]
    public class ProductsController : ApiController
    {
        private readonly IProductDataManger _manager;

        public ProductsController() : this(new ProductDataManager()) {}

        public ProductsController(IProductDataManger manager)
        {
            _manager = manager ?? throw new ArgumentNullException(nameof(manager));
        }

        [Route("{productId}")]
        public string GetProduct(string locale, string productId)
        {
            var product = _manager.GetProduct(productId, locale);
            return new JavaScriptSerializer().Serialize(product);
        }
    }
}
