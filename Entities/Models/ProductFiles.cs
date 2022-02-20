using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class ProductFiles
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string FileSize { get; set; }
        public string FileName { get; set; }
        
        public bool IsMain { get; set; }
        [Key]
        public virtual Product Product { get; set; }
    }
}