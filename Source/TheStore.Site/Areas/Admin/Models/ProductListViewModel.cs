namespace TheStore.Site.Areas.Admin.Models
{
    public class ProductListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CreatedOn { get; set; }

        public string UpdatedOn { get; set; }

        public string IsVisible { get; set; }

        public int DisplayOrder { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}