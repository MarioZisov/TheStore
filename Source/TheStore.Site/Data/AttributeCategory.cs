namespace TheStore.Site.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AttributeCategory
    {
        [Key]
        [Column(Order = 1)]
        public int AttributeId { get; set; }

        [ForeignKey(nameof(AttributeId))]
        public ProductAttribute Attribute{ get; set; }

        [Key]
        [Column(Order = 2)]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}