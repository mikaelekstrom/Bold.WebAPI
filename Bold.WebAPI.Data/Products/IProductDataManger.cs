using Bold.WebAPI.Model.Product;

namespace Bold.WebAPI.Data.Products
{
    public interface IProductDataManger
    {
        Product GetProduct(string productId, string locale);
    }
}
