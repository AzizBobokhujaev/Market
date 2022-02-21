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
        public string Name { get; set; } // название продкута
        public decimal Price { get; set; } // цена продукта
        public string Color { get; set; } // цвет продукта
        public string Description { get; set; }
        public double Size { get; set; } // размеры продукта
        public Seasons Seasons { get; set; } 
        public string Material { get; set; } 
        public string Image { get; set; }
        public string Types { get; set; } // тип
        public int Width { get; set; } // ширина
        public int Length { get; set; } //длина 
        public int Thickness { get; set; }//толщина
        public string BeltMaterial { get; set; }//материал ремня
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public bool IsNew { get; set; } // новинки
        public bool IsSale { get; set; } // скидки
        public bool IsTop { get; set; } // в топе4
        public int CategoryId { get; set; }
        public int UserId { get; set; }
       // public virtual IEnumerable<ProductImage> ProductImages { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        
        public virtual ICollection<ProductImage> ProductFiles { get; set; }
        
        public virtual ICollection<Order> Orders { get; set; }




    }
}