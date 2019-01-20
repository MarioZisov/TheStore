namespace TheStore.Core.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public long UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public DateTime CreatedOn { get; set; }

        public decimal Total { get; set; }
    }
}