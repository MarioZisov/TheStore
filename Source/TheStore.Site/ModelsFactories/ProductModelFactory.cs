namespace TheStore.Site.ModelsFactories
{
    using TheStore.Core.Domain;
    using TheStore.Site.Areas.Admin.Models;
    using TheStore.Site.ModelsFactories.Interfaces;
    using TheStore.Site.Resources.PagesTexts;

    public class ProductModelFactory : IProductModelFactory
    {
        public ProductListViewModel ProduceCategoryListModel(Product product)
        {
            var vm = new ProductListViewModel
            {
                Id = product.Id,
                Name = product.Name,
                CreatedOn = product.CretedOn.ToString(),
                UpdatedOn = product.UpdatedOn.HasValue ? product.UpdatedOn.ToString() : GlobalTexts.NoValueMark,
                Price = product.Price,
            };

            return vm;
        }
    }
}