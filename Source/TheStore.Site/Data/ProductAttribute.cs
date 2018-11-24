namespace TheStore.Site.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Attributes")]
    public class ProductAttribute
    {
        public ProductAttribute()
        {
            this.Translations = new HashSet<AttributeTranslation>();
            this.Values = new HashSet<AttributeValue>();
            this.Category = new HashSet<AttributeCategory>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<AttributeTranslation> Translations { get; set; }

        public ICollection<AttributeValue> Values { get; set; }

        public ICollection<AttributeCategory> Category { get; set; }
    }
}