namespace TheStore.Site.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductAttributeValue
    {
        public ProductAttributeValue()
        {
            this.ProductsAttributesMapping = new HashSet<ProductAttributeMapping>();
        }   
        
        [Key]
        public int Id { get; set; }

        public int ProductAttributeId { get; set; }

        [ForeignKey(nameof(ProductAttributeId))]
        public ProductAttribute ProductAttribute { get; set; }

        public string Value { get; set; }


        public ICollection<ProductAttributeMapping> ProductsAttributesMapping { get; set; }
    }
}