namespace TheStore.Site.Areas.Admin.Models
{
    public class CategoryListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CreatedOn { get; set; }

        public string UpdatedOn { get; set; }

        public string IsPrimary { get; set; }

        public string IsVisible { get; set; }

        public int DisplayOrder { get; set; }
    }
}       