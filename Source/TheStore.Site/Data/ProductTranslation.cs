namespace TheStore.Site.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductTranslation
    {
        [Key]
        [Column(Order = 1)]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        [MinLength(5)]
        [MaxLength(5)]
        public string Culture { get; set; }

        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}