namespace TheStore.Services.CategoryServiceComponents
{
    using System.Collections.Generic;

    public class CreateCategoryRequest
    {
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsPrimary { get; set; }

        public bool Visible { get; set; }

        public int PictureId { get; set; }

        public IEnumerable<int> SelectedCategoriesIds { get; set; }
    }
}
