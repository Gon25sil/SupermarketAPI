using System.ComponentModel.DataAnnotations;

namespace SupermarketAPI.Domain.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public int QuantityInPackage { get; set; }
        [Required]
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}