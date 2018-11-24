namespace TheStore.Site.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AttributeTranslation
    {
        [Key]
        [Column(Order = 1)]
        public int AttributeId { get; set; }

        [ForeignKey(nameof(AttributeId))]
        public ProductAttribute Attribute { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        [MinLength(5)]
        [MaxLength(5)]
        public string Culture { get; set; }

        [Required]
        public string Name { get; set; }
    }
}