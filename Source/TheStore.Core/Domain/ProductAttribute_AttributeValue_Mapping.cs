namespace TheStore.Core.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductAttribute_AttributeValue_Mapping    
    {
        [Key]
        [Column(Order = 1)]
        public int AttributeId { get; set; }

        [ForeignKey(nameof(AttributeId))]
        public virtual ProductAttribute Attribute { get; set; }

        [Key]
        [Column(Order = 2)]
        public int AttributeValueId { get; set; }

        [ForeignKey(nameof(AttributeValueId))]
        public virtual ProductAttributeValue AttributeValue { get; set; }
    }
}
