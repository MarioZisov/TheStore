namespace TheStore.Site.ModelsFactories.Interfaces
{
    using TheStore.Core.Domain;
    using TheStore.Site.Areas.Admin.Models;

    public interface ICategoryModelFactory
    {
        CategoryListViewModel ProduceCategoryListModel(Category category);

        CategoryViewModel ProduceCategoryEditModel(Category category);

        CategoryViewModel ProduceCategroyCreateModel();
    }
}