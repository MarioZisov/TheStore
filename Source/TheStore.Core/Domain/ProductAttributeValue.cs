namespace TheStore.Core.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProductAttributeValue
    {
        public ProductAttributeValue()
        {
            this.AttributesMapping = new HashSet<ProductAttribute_AttributeValue_Mapping>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ProductAttribute_AttributeValue_Mapping> AttributesMapping { get; set; }
    }
}
