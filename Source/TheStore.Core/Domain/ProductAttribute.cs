namespace TheStore.Core.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProductAttribute : BaseEntity
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