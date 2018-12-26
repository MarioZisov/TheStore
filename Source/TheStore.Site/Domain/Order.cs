namespace TheStore.Site.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using TheStore.Site.Models;

    public class Order : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public DateTime CreatedOn { get; set; }

        public decimal Total { get; set; }
    }
}