namespace TheStore.Site.ModelsFactories
{
    using System;
    using System.Linq;
    using TheStore.Core.Domain;
    using TheStore.Services.Interfaces;
    using TheStore.Site.Areas.Admin.Models;
    using TheStore.Site.Extensions;
    using TheStore.Site.ModelsFactories.Interfaces;
    using TheStore.Site.Resources.PagesTexts;

    public class CategoryModelFactory : ICategoryModelFactory
    {
        private readonly ICategoryService categoryService;

        public CategoryModelFactory(ICategoryService categoryService)
        {
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        public CategoryListViewModel ProduceCategoryListModel(Category category)
        {
            var vm = new CategoryListViewModel
            {
                Id = category.Id,
                Name = category.Name,
                CreatedOn = category.CretedOn.ToString(),
                UpdatedOn = category.UpdatedOn.HasValue ? category.UpdatedOn.ToString() : GlobalTexts.NoValueMark,
                IsPrimary = category.IsPrimary.AsText(),
                IsVisible = category.Visible.AsText(),
                DisplayOrder = category.DisplayOrder,
            };

            return vm;
        }

        public CategoryViewModel ProduceCategoryEditModel(Category category)
        {
            var dropDownItems = this.categoryService.GetAll()
                .Where(x => x.Id != category.Id)
                .Select(x => new MultiSelectDropDownListItem
            {
                Id = x.Id.ToString(),
                Text = x.Name,
                Checked = false,
            })
            .ToList();
            
            var subcategoriesIds = category.Subcategories.Select(x => x.Id.ToString());
            foreach (var listItem in dropDownItems)
            {
                if (subcategoriesIds.Contains(listItem.Id))
                    listItem.Checked = true;
            }

            var vm = new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Order = category.DisplayOrder,
                Visible = category.Visible,
                IsPrimary = category.IsPrimary,
            };

            vm.Subcategories.ListItems = dropDownItems;
            vm.PictureSelector.PictureId = category.PictureId;

            return vm;
        }

        public CategoryViewModel ProduceCategroyCreateModel()
        {
            var dropDownItems = this.categoryService.GetAll().Select(x => new MultiSelectDropDownListItem
            {
                Id = x.Id.ToString(),
                Text = x.Name,
                Checked = false,
            });

            var vm = new CategoryViewModel();
            vm.Subcategories.ListItems = dropDownItems;

            return vm; 
        }
    }
}