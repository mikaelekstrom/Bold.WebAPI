using System;
using System.Collections.Generic;
using System.Linq;
using Bold.WebAPI.Data.Helpers;
using Dacsa.Data.Entities.Objects;
using Dacsa.Framework.Shared.Interfaces;

namespace Bold.WebAPI.Data.Products
{
    internal class ProductManager
    {
        private readonly IServer _server;
        public ProductManager() : this(ServiceHelper.GetIServerServiceWrapper()) {}

        public ProductManager(IServer service)
        {
            _server = service ?? throw new ArgumentNullException(nameof(service));
        }

        public List<GroupTreeNodesView> GetTreeNodesForTreeAndLanguage(int treeId, int languageId)
        {
            var nodes = _server.GetGroupTreeNodes(treeId, languageId);
            return nodes?.ToList() ?? new List<GroupTreeNodesView>();
        }
    }
}
