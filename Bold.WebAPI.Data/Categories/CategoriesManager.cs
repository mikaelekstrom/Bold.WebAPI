using System;
using System.Collections.Generic;
using Bold.WebAPI.Commons.Helpers;
using Dacsa.Data.Entities.DTO.ProductManagement;
using Dacsa.Framework.Shared.Interfaces;

namespace Bold.WebAPI.Data.Categories
{
    public class CategoriesManager : ICategoriesManager
    {
        private readonly IServer _server;

        public CategoriesManager() : this(ServiceHelper.GetIServerServiceWrapper()) {}
        public CategoriesManager(IServer server)
        {
            _server = server ?? throw new ArgumentNullException(nameof(server));
        }

        public void GetAllTrees()
        {
            var data = _server.GetGroupTrees();
        }

        public void GetTreeById(int treeId)
        {
            var languages = _server.GetAllLanguages();
            var versions = new List<GroupTreeProperties>();
            foreach (var language in languages)
            {
                var tree = _server.GetGroupTreeWithNodes(treeId, language.Id);
                versions.Add(tree);
            }
        }
    }
}
