namespace TheStore.Site.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AttributeValueTranslations
    {
        [Key]
        [Column(Order = 1)]
        public int AttributeValueId { get; set; }

        [ForeignKey(nameof(AttributeValueId))]
        public AttributeValue AttributeValue { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        [MinLength(5)]
        [MaxLength(5)]
        public string Culture { get; set; }

        [Required]
        public string Value { get; set; }
    }
}