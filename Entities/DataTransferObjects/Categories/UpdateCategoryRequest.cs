using System.Collections.Generic;

namespace Entities.DataTransferObjects.Categories
{
    public class UpdateCategoryRequest
    {
        public Dictionary<string,string> Name { get; set; }
        public int? ParentId { get; set; }
        
    }
}