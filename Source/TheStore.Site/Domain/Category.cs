namespace TheStore.Site.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category : BaseEntity
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

        public bool IsPrimary { get; set; }

        public bool Deleted { get; set; }

        public DateTime CretedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public ICollection<Category> Subcategories{ get; set; }

        public ICollection<ProductCategory> Products { get; set; }
    }
}   