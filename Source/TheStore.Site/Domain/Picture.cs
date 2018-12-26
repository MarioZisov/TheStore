namespace TheStore.Site.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Picture : BaseEntity
    {
        public Picture()
        {
            this.ProductPicture = new HashSet<ProductPicture>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        public ICollection<ProductPicture> ProductPicture { get; set; }
    }
}