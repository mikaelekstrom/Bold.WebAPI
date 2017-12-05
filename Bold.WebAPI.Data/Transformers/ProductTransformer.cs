using System;
using System.Collections.Generic;
using System.Linq;
using Bold.WebAPI.Model.File;
using Bold.WebAPI.Model.Product;
using Dacsa.Data.Entities.DTO.Common.Resources;
using Dacsa.Data.Entities.DTO.Export.ProductSpecifications;
using Dacsa.Data.Entities.DTO.ProductManagement;
using Dacsa.Data.Entities.Objects;
using Product = Bold.WebAPI.Model.Product.Product;

namespace Bold.WebAPI.Data.Transformers
{
    public static class ProductTransformer
    {
        public static Product CreateProductFromBoldData(Tuple<SalesItemDTO, ProductSpecification> data, ProductInfoLang info,
            List<ResourcePictureDto> resourceDtos)
        {
            var productProperties = new List<Property>();
            foreach (var propertyValue in data.Item2.ProductPropertyValues)
            {
                productProperties.AddRange(
                    propertyValue.ProductProperty.PropertyLangs.Select(property => 
                        CreateProperty(property, propertyValue)));
            }
            var resources = ConvertDtosToResources(resourceDtos);
            return new Product(data.Item2.ProductId, productProperties, info, resources);
        }

        private static List<Resource> ConvertDtosToResources(IEnumerable<ResourcePictureDto> resourceDtos)
        {
            return resourceDtos.Select(dto =>
                    new Resource(dto.Id, dto.ResourceDto_ResourceTypeId, dto.FileName))
                .ToList();
        }

        private static Property CreateProperty(ProductPropertyLang property, ProductPropertyValue propertyValue)
        {
            var languageId = property.LanguageId;
            var value = propertyValue.ValueLangs.First(p => p.LanguageId.Equals(languageId)).Value;
            var unitLong = GetUnit(propertyValue, languageId, true);
            var unitShort = GetUnit(propertyValue, languageId, false);
            return new Property(property.PropertiesId, languageId, property.Name, unitLong, unitShort, value);
        }

        private static string GetUnit(ProductPropertyValue propertyValue, int languageId, bool longName)
        {
            var unitData = propertyValue.ProductProperty.EntryUnit?.UnitsLangs
                .FirstOrDefault(p => p.LanguageId.Equals(languageId));
            if (unitData == null)
                return string.Empty;
            return longName ? unitData.LongName : unitData.ShortName;
        }
    }
}
