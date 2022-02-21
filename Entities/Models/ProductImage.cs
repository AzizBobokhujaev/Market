using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        //public string FileSize { get; set; }
        public string ImagePath { get; set; }

        public bool IsMain { get; set; }
        
        public virtual Product Product { get; set; }
    }
}