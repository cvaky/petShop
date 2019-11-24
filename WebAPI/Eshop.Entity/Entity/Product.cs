using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eshop.Entity.Entity
{
    public class Product: BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string Description { get; set; }
        [Required]

        public int AnimalCategoryId { get; set; }

        public virtual AnimalCategory AnimalCategory { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
