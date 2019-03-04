namespace TheStore.Site.Controllers.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using TheStore.Services.Interfaces;
    using TheStore.Site.Areas.Admin.Models;
    using TheStore.Site.ModelsFactories.Interfaces;

    public class CategoryController : ApiController
    {
        private readonly ICategoryService CategoryService;
        private readonly ICategoryModelFactory CategoryModelFactory;

        public CategoryController(ICategoryService categoryService, ICategoryModelFactory categoryModelFactory)
        {
            this.CategoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            this.CategoryModelFactory = categoryModelFactory ?? throw new ArgumentNullException(nameof(categoryModelFactory));
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = this.CategoryService.GetAll();
            var vModels = data.Select(x => this.CategoryModelFactory.ProduceCategoryListModel(x));

            return this.Ok(vModels);
        }
        
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var category = this.CategoryService.Delete(id);
                if (category == null)
                    return this.NotFound();

                return this.Ok(category.Id);
            }
            catch (Exception)
            {
                // TODO: Log the exception.
                return this.BadRequest();
                throw;
            }
        }
    }
}
