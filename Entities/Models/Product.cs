using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using Entities.Enums;
using Microsoft.VisualBasic;

namespace Entities.Models
{
    public class  Product
    {
        [Key]
        public int Id { get; set; }// номер продукта
        [Column(TypeName = "jsonb")]
        public Dictionary<string,string> Name { get; set; } // название продкута
        public decimal Price { get; set; } // цена продукта
        public Seasons Seasons { get; set; } 
        [Column(TypeName = "jsonb")]
        public Dictionary<string,string> Material { get; set; } 
        public int? Width { get; set; } // ширина
        public int? Length { get; set; } //длина 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public bool IsNew { get; set; } // новинки
        public bool IsSale { get; set; } // скидки
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual int[] Size { get; set; }
        public virtual IEnumerable<ProductImage> ProductImages { get; set; }




    }
}