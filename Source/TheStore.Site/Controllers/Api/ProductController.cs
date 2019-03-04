namespace TheStore.Site.Controllers.Api
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using TheStore.Services.Interfaces;
    using TheStore.Site.ModelsFactories.Interfaces;

    public class ProductController : ApiController
    {
        private readonly IProductService ProductService;
        private readonly IProductModelFactory ProductModelFactory;

        public ProductController(IProductService productService, IProductModelFactory productModelFactory)
        {
            this.ProductService = productService ?? throw new ArgumentNullException(nameof(productService));
            this.ProductModelFactory = productModelFactory ?? throw new ArgumentNullException(nameof(productModelFactory));
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = this.ProductService.GetAll();
            var vModels = data.Select(x => this.ProductModelFactory.ProduceCategoryListModel(x));

            return this.Ok(vModels);
        }
    }
}
