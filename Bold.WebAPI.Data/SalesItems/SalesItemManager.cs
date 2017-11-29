using System;
using System.Collections.Generic;
using System.Linq;
using Bold.Shared.Types.GeneratedCode.Enums;
using Bold.WebAPI.Commons.Helpers;
using Dacsa.Data.Entities.DTO.Common.Resources;
using Dacsa.Data.Entities.DTO.ProductManagement;
using Dacsa.Data.Entities.Objects;
using Dacsa.Framework.Shared.Interfaces;
using ProductSpecification = Dacsa.Data.Entities.DTO.Export.ProductSpecifications.ProductSpecification;

namespace Bold.WebAPI.Data.SalesItems
{
    public class SalesItemManager : ISalesItemsManager
    {
        private readonly IServer _server;

        public SalesItemManager() : this(ServiceHelper.GetIServerServiceWrapper()) {}

        public SalesItemManager(IServer server)
        {
            _server = server ?? throw new ArgumentNullException(nameof(server));
        }
        public List<GroupTreeNodesView> GetNodeTreeByTreeId(int treeId, int languageId)
        {
            return _server.GetGroupTreeNodes(treeId, languageId).ToList();
        }
        public List<SalesItemDTO> GetSalesItemsByNodeId(int nodeId, bool showDiscontinued)
        {
            return _server.GetSalesItemsByGroupTreeNodesId(nodeId, showDiscontinued).ToList();
        }
        public SalesItemDTO GetSalesItemBySalesItemId(int salesItemId)
        {
            return _server.GetSalesItemBySalesItemId(salesItemId);
        }
        public Tuple<SalesItemDTO, ProductSpecification> GetSalesItemByProductId(string productId)
        {
            var salesItem = _server.GetSalesItemByProductId(productId);
            var spec = _server.GetProductSpecificationForProduct(productId); //_server.GetSalesItemByProductId(productId);
            var data = new Tuple<SalesItemDTO, ProductSpecification>(salesItem, spec);
            return data;
        }

        public ProductInfoLang GetProductInfo(int salesItemsId, int languageId)
        {
            return _server.GetProductInfoLangBySalesItemId(salesItemsId, languageId);
        }
        public List<ResourcePictureDto> GetResourcePicturesInfoBySalesItemId(int salesItemId)
        {
            var resourceHolder = new ResourceHolder {Id = salesItemId.ToString(), Type = ResourceHolderTypeEnum.SalesItem};
            return _server.GetResourcePictures(resourceHolder).ToList();
        }
        public List<ResourceDocumentDto> GetResourceDocumentsInfoBySalesItemId(int salesItemId)
        {
            var resourceHolder = new ResourceHolder { Id = salesItemId.ToString(), Type = ResourceHolderTypeEnum.SalesItem };
            return _server.GetResourceDocuments(resourceHolder).ToList();
        }
    }
}
