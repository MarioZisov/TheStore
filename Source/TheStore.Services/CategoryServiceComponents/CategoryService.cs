namespace TheStore.Services.CategoryServiceComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TheStore.Core.Domain;
    using TheStore.Data;
    using TheStore.Services.Interfaces;

    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }

        public Category Create(CreateCategoryRequest request)
        {
            var categories = new List<Category>();
            if (request.SelectedCategoriesIds.Any())
                categories = this.categoryRepository.Table.Where(x => request.SelectedCategoriesIds.Contains(x.Id)).ToList();

            var category = new Category
            {
                Name = request.Name,
                IsPrimary = request.IsPrimary,
                Visible = request.Visible,
                DisplayOrder = request.DisplayOrder,
                PictureId = request.PictureId,
                Subcategories = categories,
                Deleted = false,
                CretedOn = DateTime.Now,
            };

            this.categoryRepository.Insert(category);

            return category;
        }

        public Category GetById(int id)
        {
            return this.categoryRepository.GetById(id);
        }

        public IEnumerable<Category> GetAll()
        {
            var categories = this.categoryRepository.Table.Where(x => x.Deleted == false).ToList();
            return categories;
        }
    }
}