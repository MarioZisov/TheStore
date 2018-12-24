namespace TheStore.Site.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using TheStore.Site.Models;

    public class ProductAttribute
    {
        public ProductAttribute()
        {
            this.ProductAttributeValues = new HashSet<ProductAttributeValue>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<ProductAttributeValue> ProductAttributeValues { get; set; }
    }
}