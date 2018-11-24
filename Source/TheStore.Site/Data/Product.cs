namespace TheStore.Site.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
            this.Translations = new HashSet<ProductTranslation>();
            this.PriceCurrencies = new HashSet<ProductPriceCurrency>();
            this.ProductsAttributesValues = new HashSet<ProductAttributeValue>();
            this.AdditionalAttributesValues = new HashSet<AdditionalAttributeValue>();
            this.VarietyProducts = new HashSet<Product>();
            this.Categories = new HashSet<ProductCategory>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public ICollection<ProductTranslation> Translations { get; set; }

        public ICollection<ProductPriceCurrency> PriceCurrencies { get; set; }

        public ICollection<ProductAttributeValue> ProductsAttributesValues { get; set; }

        public ICollection<AdditionalAttributeValue> AdditionalAttributesValues { get; set; }

        public ICollection<Product> VarietyProducts { get; set; }

        public ICollection<ProductCategory> Categories { get; set; }
    }
}