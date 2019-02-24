namespace TheStore.Services.CategoryServiceComponents
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using TheStore.Core.Common;
    using TheStore.Core.Domain;
    using TheStore.Data;
    using TheStore.Services.Interfaces;

    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> CategoryRepository;
        private readonly IPictureService PictureService;

        public CategoryService(IRepository<Category> categoryRepository, IPictureService pictureService)
        {
            this.CategoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            this.PictureService = pictureService ?? throw new ArgumentNullException(nameof(pictureService));
        }

        public Category Create(CreateCategoryRequest request)
        {
            var categories = new List<Category>();
            if (request.SelectedCategoriesIds.Any())
                categories = this.CategoryRepository.Table.Where(x => request.SelectedCategoriesIds.Contains(x.Id)).ToList();

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

            this.CategoryRepository.Insert(category);

            return category;
        }

        public void Update(UpdateCategoryRequest request)
        {
            var category = this.CategoryRepository.GetById(request.Id);

            category.Name = request.Name;
            category.DisplayOrder = request.DisplayOrder;
            category.IsPrimary = request.IsPrimary;
            category.Visible = request.Visible;

            if (request.PictureId.HasValue)
                category.PictureId = request.PictureId.Value;

            category.Subcategories.Clear();

            var subcategories = this.CategoryRepository.Table.Where(x => request.SelectedCategoriesIds.Contains(x.Id)).ToList();
            category.Subcategories = subcategories;

            category.UpdatedOn = DateTime.Now;

            this.CategoryRepository.Update(category);
        }

        public Category Delete(int id)
        {
            var category = this.CategoryRepository.GetById(id);
            if (category != null)
            {
                category.Deleted = true;
                category.UpdatedOn = DateTime.Now;
                this.CategoryRepository.Update(category);
                this.PictureService.Delete(category.PictureId);

                return category;
            }

            return null;
        }

        public Category GetById(int id)
        {
            return this.CategoryRepository.GetById(id);
        }

        public IEnumerable<Category> GetAll()
        {
            var categories = this.CategoryRepository.Table.Where(x => x.Deleted == false).ToList();
            return categories;
        }
    }
}