﻿namespace Entities.DataTransferObjects.Categories
{
    public class UpdateCategoryRequest
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        
    }
}