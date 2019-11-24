using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eshop.Entity.Entity
{
    public class AnimalCategory : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
