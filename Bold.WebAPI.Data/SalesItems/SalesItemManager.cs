using System;
using System.Collections.Generic;
using System.Linq;
using Bold.Shared.Types.GeneratedCode.Enums;
using Bold.WebAPI.Data.Helpers;
using Dacsa.Data.Entities.DTO.Common.Resources;
using Dacsa.Data.Entities.DTO.ProductManagement;
using Dacsa.Data.Entities.Objects;
using Dacsa.Framework.Shared.Interfaces;

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
        public List<GroupTreeNodesView> GetNodeTreeByTreeId(int treeId, int languageId = 0)
        {
            if (languageId != 0)
                return _server.GetGroupTreeNodes(treeId, languageId).ToList();
            var setting = _server.GetApplicationSettingByKey(ApplicationSettingSections.None, 
                ApplicationSettingSectionIds.All, ApplicationSettingKeys.SystemDefaultLanguageId);
            _server.GetApplicationSettingByKey(ApplicationSettingSections.None, ApplicationSettingSectionIds.All, ApplicationSettingKeys.SystemDefaultLanguageId);
            int.TryParse(setting.SettingValue, out languageId);
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
        public SalesItemDTO GetSalesItemByProductId(string productId)
        {
            return _server.GetSalesItemByProductId(productId);
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
