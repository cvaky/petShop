using System;
using System.ComponentModel.DataAnnotations;

namespace Eshop.Entity.Entity
{
    public class Order : BaseEntity
    {
        [Required]
        public double TotalPrice { get; set; }
        [Required]
        [Range(1, 1000)]
        public int ProductCount { get; set; }
        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [DataType(DataType.Date)]
        public DateTime TimeStamp { get; set; }
    }
}
