using System.Collections.Generic;
using Entities.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.DataTransferObjects.Products
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string? Size { get; set; }
        public string? Material { get; set; }
        public string? Types { get; set; }
        public int? Width { get; set; }
        public int? Length { get; set; }
        //public IFormFile MainImage { get; set; }
       // public List<IFormFile> Images { get; set; }
        public Seasons Seasons { get; set; }
    }
}