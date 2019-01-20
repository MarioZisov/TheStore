namespace TheStore.Core.Domain
{
    using System.ComponentModel.DataAnnotations;

    public class ProductAttributeType : BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}