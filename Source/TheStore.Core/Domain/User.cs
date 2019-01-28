namespace TheStore.Core.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User : BaseEntity
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
        }

        [Key]
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        public DateTime? LastLogin { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsBlocked { get; set; }

        public ICollection<Order> Orders { get; set; }        
    }
}