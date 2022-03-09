using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        [Column(TypeName = "jsonb")]
        public Dictionary<string,string> Name { get; set; }
        
        public virtual ICollection<Category> SubCategory { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
        
    }   
}