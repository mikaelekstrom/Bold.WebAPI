using System;
using System.Collections.Generic;
using Bold.WebAPI.Model.File;
using Dacsa.Data.Entities.Objects;

namespace Bold.WebAPI.Model.Product
{
    public class Product
    {
        public List<Resource> Resources { get; }
        public string ProductId { get; }
        public ProductInfoLang ProductInfo { get; }
        public List<Property> ProductProperties { get; }

        public Product(string productId, List<Property> productProperties, ProductInfoLang productInfo,
            List<Resource> resources)
        {
            Resources = resources ?? throw new ArgumentNullException(nameof(resources));
            ProductId = productId ?? throw new ArgumentNullException(nameof(productId));
            ProductInfo = productInfo ?? throw new ArgumentNullException(nameof(productInfo));
            ProductProperties = productProperties ?? throw new ArgumentNullException(nameof(productProperties));
        }
    }
}
