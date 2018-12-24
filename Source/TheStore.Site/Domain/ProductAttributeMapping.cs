namespace TheStore.Site.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductAttributeMapping
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public int ProductAttributeId { get; set; }

        [ForeignKey(nameof(ProductAttributeId))]
        public ProductAttribute ProductAttribute { get; set; }

        public int? ProductAttributeValueId { get; set; }

        [ForeignKey(nameof(ProductAttributeValueId))]
        public ProductAttributeValue ProductAttributeValue { get; set; }

        public int ProductAttributeTypeId { get; set; }

        [ForeignKey(nameof(ProductAttributeTypeId))]
        public ProductAttributeType ProductAttributeType { get; set; }

        public string CustomValue { get; set; }

        public string XmlValue { get; set; }

        public bool AllowFiltering { get; set; }

        public bool ShowOnPage { get; set; }

        public decimal PriceAdjustment { get; set; }
    }
}