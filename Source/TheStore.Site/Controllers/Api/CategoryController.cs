namespace TheStore.Site.Controllers.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using TheStore.Core.Domain;
    using TheStore.Services.Interfaces;
    using TheStore.Site.Areas.Admin.Models;
    using TheStore.Site.ModelsFactories;
    using TheStore.Site.ModelsFactories.Interfaces;

    public class CategoryController : ApiController
    {
        private readonly ICategoryService categoryService;
        private readonly ICategoryModelFactory categoryModelFactory;

        public CategoryController(ICategoryService categoryService, ICategoryModelFactory categoryModelFactory)
        {
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            this.categoryModelFactory = categoryModelFactory ?? throw new ArgumentNullException(nameof(categoryModelFactory));
        }

        public IEnumerable<CategoryListViewModel> Get()
        {
            var data = this.categoryService.GetAll();
            var vModels = data.Select(x => this.categoryModelFactory.ProduceCategoryListModel(x));
            return vModels;
        }
    }
}
