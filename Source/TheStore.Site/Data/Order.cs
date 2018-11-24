namespace TheStore.Site.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using TheStore.Site.Models;

    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public DateTime OrderDate { get; set; }

        [Range(typeof(decimal), "0", "100000000")]
        public decimal Total { get; set; }
    }
}