﻿using System.Collections.Generic;
using Entities.Enums;

namespace Entities.DataTransferObjects.Products
{
    public class UpdateProductRequest
    {
        public Dictionary<string,string> Name { get; set; }
        public decimal Price { get; set; }
        public Dictionary<string,string> Material { get; set; }
        public int? Width { get; set; }
        public bool IsSale { get; set; }
        public int? Length { get; set; }
        public int[] Size { get; set; }
        public Seasons Seasons { get; set; }
    }
}