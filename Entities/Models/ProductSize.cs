using System.Text.Json;

namespace Entities.Models
{
    public class ProductSize
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Size { get; set; }
    }
}