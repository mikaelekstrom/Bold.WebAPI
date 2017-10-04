using System;
using System.Web.Http;
using Bold.WebAPI.Data.SalesItems;
using Microsoft.Web.Http;

namespace Bold.WebAPI.Controllers
{
    [ApiVersion("2.0")]
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private readonly ISalesItemsManager _manager;

        public ProductsController() : this(new SalesItemManager()) {}

        public ProductsController(ISalesItemsManager salesManager)
        {
            if (salesManager == null) throw new ArgumentNullException(nameof(salesManager));
            _manager = salesManager;
        }

        public string GetProduct(string id)
        {
            /*
            var productData = _manager.GetSalesItemByProductId(id);
            return productData.ToString();
            */
            return $"You asked for produt {id}.";
        }

    }
}
