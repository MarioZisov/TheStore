namespace TheStore.Site.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        public Category()
        {
            this.Subcategories = new HashSet<Category>();
            this.Products = new HashSet<ProductCategory>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
       
        public ICollection<Category> Subcategories{ get; set; }

        public ICollection<ProductCategory> Products { get; set; }
    }
}   