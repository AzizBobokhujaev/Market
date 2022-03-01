using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string NameRu { get; set; }
        public string NameTj { get; set; }
        public string NameCh { get; set; }
        
        
        
        public virtual ICollection<Category> SubCategory { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
        
    }   
}