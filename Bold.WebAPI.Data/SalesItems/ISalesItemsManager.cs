using System.Collections.Generic;
using Dacsa.Data.Entities.DTO.Common.Resources;
using Dacsa.Data.Entities.DTO.ProductManagement;
using Dacsa.Data.Entities.Objects;

namespace Bold.WebAPI.Data.SalesItems
{
    public interface ISalesItemsManager
    {
        List<GroupTreeNodesView> GetNodeTreeByTreeId(int treeId, int languageId = 0);
        List<SalesItemDTO> GetSalesItemsByNodeId(int nodeId, bool showDiscontinued);
        SalesItemDTO GetSalesItemBySalesItemId(int salesItemId);
        SalesItemDTO GetSalesItemByProductId(string productId);
        List<ResourcePictureDto> GetResourcePicturesInfoBySalesItemId(int salesItemId);
        List<ResourceDocumentDto> GetResourceDocumentsInfoBySalesItemId(int salesItemId);
    }
}
