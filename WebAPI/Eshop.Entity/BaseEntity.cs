using System.ComponentModel.DataAnnotations;

namespace Eshop.Entity.Entity
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
