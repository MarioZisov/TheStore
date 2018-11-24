namespace TheStore.Site.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductAttributeValue
    {
        [Key]
        [Column(Order = 1)]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [Key]
        [Column(Order = 2)]
        public int AttributeValueId { get; set; }

        [ForeignKey(nameof(AttributeValueId))]
        public AttributeValue AttributeValue { get; set; }
    }
}