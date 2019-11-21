using System;
using System.Collections.Generic;
using System.Text;

namespace Eshop.Entity.Entity
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public int AnimalCategoryId { get; set; }

        public virtual AnimalCategory AnimalCategory { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
