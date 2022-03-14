using System.Collections.Generic;
using Entities.Enums;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.DataTransferObjects.Products
{
    public class CreateProductRequest
    {
        public Dictionary<string,string> Name { get; set; }
        public decimal Price { get; set; }
        public Dictionary<string,string> Material { get; set; }
        public int? Width { get; set; }
        public int? Length { get; set; }
        public bool IsNew { get; set; }
        public Seasons Seasons { get; set; }
        public int[] Size { get; set; }
    }
}