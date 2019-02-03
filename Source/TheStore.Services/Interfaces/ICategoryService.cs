namespace TheStore.Services.Interfaces
{
    using System.Collections.Generic;
    using TheStore.Core.Domain;
    using TheStore.Services.CategoryServiceComponents;

    public interface ICategoryService
    {
        Category Create(CreateCategoryRequest category);

        IEnumerable<Category> GetAll();
    }
}
