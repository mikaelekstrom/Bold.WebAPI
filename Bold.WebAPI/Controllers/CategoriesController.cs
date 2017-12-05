using System;
using System.Web.Http;
using Bold.WebAPI.Data.Categories;

namespace Bold.WebAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoriesManager _categoriesManager;

        public CategoriesController() : this(new CategoriesManager()) {}

        public CategoriesController(ICategoriesManager categoriesManager)
        {
            _categoriesManager = categoriesManager ?? throw new ArgumentNullException(nameof(categoriesManager));
        }
    }
}
