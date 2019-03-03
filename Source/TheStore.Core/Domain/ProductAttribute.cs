namespace TheStore.Core.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProductAttribute : BaseEntity
    {
        public ProductAttribute()
        {
            this.ValuesMapping = new HashSet<ProductAttribute_AttributeValue_Mapping>();
            this.ProductsMapping = new HashSet<Product_Attribute_Mapping>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ProductAttribute_AttributeValue_Mapping> ValuesMapping { get; set; }

        public virtual ICollection<Product_Attribute_Mapping> ProductsMapping { get; set; }
    }
}