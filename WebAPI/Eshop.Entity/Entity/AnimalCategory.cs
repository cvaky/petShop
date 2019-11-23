using System;
using System.Collections.Generic;
using System.Text;

namespace Eshop.Entity.Entity
{
    public class AnimalCategory : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
