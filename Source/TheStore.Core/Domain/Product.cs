namespace TheStore.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product : BaseEntity
    {
        public Product()
        {
            this.AttributesMapping = new HashSet<Product_Attribute_Mapping>();
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

        public virtual ICollection<Product_Attribute_Mapping> AttributesMapping { get; set; }

        public virtual ICollection<ProductCategory> Categories { get; set; }

        public virtual ICollection<ProductPicture> ProductPictures { get; set; }
    }
}