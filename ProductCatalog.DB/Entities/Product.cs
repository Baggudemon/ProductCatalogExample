using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.DB.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(140)]
        public string Name { get; set; }

        // Foreign key
        public int ProductTypeId { get; set; }
        // Navigation property
        public ProductType ProductType { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
