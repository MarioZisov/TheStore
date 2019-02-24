namespace TheStore.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Picture : BaseEntity
    {
        public Picture()
        {
            this.ProductsPictures = new HashSet<ProductPicture>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string FullPath { get; set; }

        [Required]
        public string Url { get; set; }

        public DateTime UploadDate { get; set; }

        public bool Deleted { get; set; }

        public DateTime? DeletedDate { get; set; }

        public virtual ICollection<ProductPicture> ProductsPictures { get; set; }
    }
}