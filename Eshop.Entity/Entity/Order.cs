using System;

namespace Eshop.Entity.Entity
{
    public class Order : BaseEntity
    {
        public double TotalPrice { get; set; }
        public int ProductCount { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
