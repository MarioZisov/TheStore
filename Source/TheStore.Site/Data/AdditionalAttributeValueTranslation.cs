namespace TheStore.Site.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AdditionalAttributeValueTranslation
    {
        [Key]
        [Column(Order = 1)]
        public int AdditionalAttributeValueId { get; set; }

        [ForeignKey(nameof(AdditionalAttributeValueId))]
        public AdditionalAttributeValue AdditionalAttributeValue { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        [MinLength(5)]
        [MaxLength(5)]
        public string Culture { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Value { get; set; }
    }
}