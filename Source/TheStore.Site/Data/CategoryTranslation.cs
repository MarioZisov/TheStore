namespace TheStore.Site.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CategoryTranslation
    {
        [Key]
        [Column(Order = 1)]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category{ get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        [MinLength(5)]
        [MaxLength(5)]
        public string Culture { get; set; }

        [Required]
        public string Name { get; set; }
    }
}