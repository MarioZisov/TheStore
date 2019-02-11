namespace TheStore.Site.Controllers.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using TheStore.Core.Domain;
    using TheStore.Services.Interfaces;
    using TheStore.Site.Areas.Admin.Models;

    public class CategoryController : ApiController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        public IEnumerable<CategoryListViewModel> Get()
        {
            var data = this.categoryService.GetAll();
            var vModels = data.Select(x => new CategoryListViewModel(x));
            return vModels;
        }
    }
}
