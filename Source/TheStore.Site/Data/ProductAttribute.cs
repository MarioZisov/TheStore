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
            this.Values = new HashSet<AttributeValue>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<AttributeValue> Values { get; set; }
    }
}