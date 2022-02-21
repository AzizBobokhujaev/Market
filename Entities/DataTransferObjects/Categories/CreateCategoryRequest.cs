using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.Categories
{
    public class CreateCategoryRequest
    {
        [Required] 
        public string Name { get; set; }

        public int? ParentId { get; set; }
        
    }
}