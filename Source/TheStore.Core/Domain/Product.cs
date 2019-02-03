namespace TheStore.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product : BaseEntity
    {
        public Product()
        {
            this.ProductsAttributesValueMapping = new HashSet<ProductAttributeMapping>();
            this.ProductVarieties = new HashSet<Product>();
            this.Categories = new HashSet<ProductCategory>();
            this.ProductPictures = new HashSet<ProductPicture>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool Deleted { get; set; }

        public DateTime CretedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public ICollection<ProductAttributeMapping> ProductsAttributesValueMapping { get; set; }

        public ICollection<Product> ProductVarieties { get; set; }

        public ICollection<ProductCategory> Categories { get; set; }

        public ICollection<ProductPicture> ProductPictures { get; set; }
    }
}