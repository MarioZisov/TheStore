namespace TheStore.Site.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductPicture : BaseEntity
    {
        [Key]
        [Column(Order = 1)]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [Key]
        [Column(Order = 2)]
        public int PictureId { get; set; }

        [ForeignKey(nameof(PictureId))]
        public Picture Picture { get; set; }
    }
}