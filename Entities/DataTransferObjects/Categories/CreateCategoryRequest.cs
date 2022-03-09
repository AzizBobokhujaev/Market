using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Categories
{
    public class CreateCategoryRequest
    {
        [Required] 
        public Dictionary<string,string> Name { get; set; }

        public int? ParentId { get; set; }
        
    }
}