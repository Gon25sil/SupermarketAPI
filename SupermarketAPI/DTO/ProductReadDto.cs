
namespace SupermarketAPI.DTO
{
    public class ProductReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int QuantityInPackage { get; set; }
        
        public string UnitOfMeasurement { get; set; }

        public CategoryReadDto Category { get; set; }
    }
}
