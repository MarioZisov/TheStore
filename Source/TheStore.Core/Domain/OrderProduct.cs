﻿namespace TheStore.Core.Domain
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderProduct : BaseEntity
    {
        [Key]
        [Column(Order = 1)]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}