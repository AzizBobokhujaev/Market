using System.Collections.Generic;

namespace Entities.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
        
    }   
}