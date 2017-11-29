using System;
using System.Collections.Generic;
using Dacsa.Data.Entities.DTO.Common.Resources;
using Dacsa.Data.Entities.DTO.Export.ProductSpecifications;
using Dacsa.Data.Entities.DTO.ProductManagement;
using Dacsa.Data.Entities.Objects;

namespace Bold.WebAPI.Data.SalesItems
{
    public interface ISalesItemsManager
    {
        List<GroupTreeNodesView> GetNodeTreeByTreeId(int treeId, int languageId);
        List<SalesItemDTO> GetSalesItemsByNodeId(int nodeId, bool showDiscontinued);
        SalesItemDTO GetSalesItemBySalesItemId(int salesItemId);
        Tuple<SalesItemDTO, ProductSpecification> GetSalesItemByProductId(string productId);
        ProductInfoLang GetProductInfo(int salesItemsId, int languageId);
        List<ResourcePictureDto> GetResourcePicturesInfoBySalesItemId(int salesItemId);
        List<ResourceDocumentDto> GetResourceDocumentsInfoBySalesItemId(int salesItemId);
    }
}
