namespace TheStore.Core.Domain
{
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product_Attribute_Mapping : BaseEntity
    {
        public Product_Attribute_Mapping()
        {
            this.ProductsAttributesValuesMapping = new HashSet<Product_Attribute_Value_Mapping>();
        }

        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        public int ProductAttributeId { get; set; }

        [ForeignKey(nameof(ProductAttributeId))]
        public virtual ProductAttribute ProductAttribute { get; set; }

        public bool AllowFiltering { get; set; }

        public bool ShowOnPage { get; set; }

        public decimal PriceAdjustment { get; set; }
        
        public int AttributeTypeId { get; set; }

        [ForeignKey(nameof(AttributeTypeId))]
        public ProductAttributeType AttributeType { get; set; }

        public virtual ICollection<Product_Attribute_Value_Mapping> ProductsAttributesValuesMapping { get; set; }
    }
}