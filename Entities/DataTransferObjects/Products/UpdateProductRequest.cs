using Entities.Enums;

namespace Entities.DataTransferObjects.Products
{
    public class UpdateProductRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public int? Width { get; set; }
        public bool IsSale { get; set; }
        public int? Length { get; set; }
        public Seasons Seasons { get; set; }
    }
}