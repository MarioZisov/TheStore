namespace TheStore.Core.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product_Attribute_Value_Mapping
    {
        [Key]
        [Column(Order = 1)]
        public int ProductAttributeMappingId { get; set; }

        [ForeignKey(nameof(ProductAttributeMappingId))]
        public virtual Product_Attribute_Mapping ProductAttributeMapping { get; set; }

        [Key]
        [Column(Order = 2)]
        public int? AttributeValueId { get; set; }

        [ForeignKey(nameof(AttributeValueId))]
        public virtual ProductAttributeValue AttributeValue { get; set; }

        public string CustomValue { get; set; }
    }
}
