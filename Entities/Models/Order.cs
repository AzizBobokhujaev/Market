using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Enums;

namespace Entities.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int PhoneNumber { get; set; }
        public Status Status { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}