namespace TheStore.Site.Controllers.Api
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using TheStore.Core.Domain;
    using TheStore.Services.Interfaces;

    public class CategoryController : ApiController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        public IEnumerable<Category> Get()
        {
            return this.categoryService.GetAll();
        }
    }
}
