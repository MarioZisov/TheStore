namespace TheStore.Core.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductPicture : BaseEntity
    {
        [Key]
        [Column(Order = 1)]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        [Key]
        [Column(Order = 2)]
        public int PictureId { get; set; }

        [ForeignKey(nameof(PictureId))]
        public virtual Picture Picture { get; set; }
    }
}