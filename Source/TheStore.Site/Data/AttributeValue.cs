namespace TheStore.Site.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AttributeValue
    {
        public AttributeValue()
        {
            this.ProductsAttributesValues = new HashSet<ProductAttributeValue>();
        }   
        
        [Key]
        public int Id { get; set; }

        public int AttributeId { get; set; }

        [ForeignKey(nameof(AttributeId))]
        public ProductAttribute Attribute { get; set; }

        public string Value { get; set; }


        public ICollection<ProductAttributeValue> ProductsAttributesValues { get; set; }
    }
}