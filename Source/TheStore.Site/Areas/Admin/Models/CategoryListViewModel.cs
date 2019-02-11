namespace TheStore.Site.Areas.Admin.Models
{
    using TheStore.Core.Domain;
    using TheStore.Site.Extensions;
    using TheStore.Site.Resources.PagesTexts;

    public class CategoryListViewModel
    {
        public CategoryListViewModel(Category category)
        {
            this.InitViewModel(category);            
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string CreatedOn { get; set; }

        public string UpdatedOn { get; set; }

        public string IsPrimary { get; set; }

        public string IsVisible { get; set; }

        public int DisplayOrder { get; set; }

        public void InitViewModel(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
            this.CreatedOn = category.CretedOn.ToString();
            this.UpdatedOn = category.UpdatedOn.HasValue ? category.UpdatedOn.ToString() : GlobalTexts.NoValueMark;
            this.IsPrimary = category.IsPrimary.AsText();
            this.IsVisible = category.Visible.AsText();
            this.DisplayOrder = category.DisplayOrder;
        }
    }
}       