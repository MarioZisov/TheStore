namespace TheStore.Site.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AdditionalAttributeValue
    {
        public AdditionalAttributeValue()
        {
            this.Translations = new HashSet<AdditionalAttributeValueTranslation>();
        }

        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [Required]
        public string Name { get; set; }    

        [Required]
        public string Value { get; set; }

        public ICollection<AdditionalAttributeValueTranslation> Translations { get; set; }
    }
}