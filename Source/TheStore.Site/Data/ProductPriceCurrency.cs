namespace TheStore.Site.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductPriceCurrency
    {
        [Key]
        [Column(Order = 1)]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        [MinLength(3)]
        [MaxLength(3)]
        public string Currency { get; set; }

        [Range(typeof(decimal), "0", "100000000")]
        public decimal Price { get; set; }
    }
}