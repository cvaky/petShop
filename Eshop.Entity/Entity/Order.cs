using System;
using System.Collections.Generic;
using System.Text;

namespace Eshop.Entity.Entity
{
    public class Order : BaseEntity
    {
        public double TotalPrice { get; set; }
        public int ProductCount { get; set; }
        public DateTime TimeStamp { get; set; }
        public virtual Product Product { get; set; }
    }
}
