namespace TheStore.Site.ModelsFactories.Interfaces
{
    using TheStore.Core.Domain;
    using TheStore.Site.Areas.Admin.Models;

    public interface IProductModelFactory
    {
        ProductListViewModel ProduceCategoryListModel(Product product);
    }
}