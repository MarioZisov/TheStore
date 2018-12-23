namespace TheStore.Site.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
            this.ProductsAttributesValues = new HashSet<ProductAttributeValue>();
            this.ProductVarieties = new HashSet<Product>();
            this.Categories = new HashSet<ProductCategory>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public ICollection<ProductAttributeValue> ProductsAttributesValues { get; set; }

        public ICollection<Product> ProductVarieties { get; set; }

        public ICollection<ProductCategory> Categories { get; set; }
    }
}