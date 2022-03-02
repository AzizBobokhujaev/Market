using Microsoft.AspNetCore.Http;

namespace Entities.DataTransferObjects.ProductImage
{
    public class ProductImageDto
    {
        public int ProductId { get; set; }
        public string Color { get; set; }
        public IFormFile[] Images { get; set; }
    }
}