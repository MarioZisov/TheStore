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
            this.AttributesCategories = new HashSet<AttributeCategory>();
            this.Translations = new HashSet<CategoryTranslation>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
       
        public ICollection<Category> Subcategories{ get; set; }

        public ICollection<ProductCategory> Products { get; set; }

        public ICollection<AttributeCategory> AttributesCategories { get; set; }

        public ICollection<CategoryTranslation> Translations { get; set; }
    }
}   