using Newtonsoft.Json;
using System.Collections.Generic;

namespace Eshop.Domain.Domain
{
    public class ProductViewModel: ShortProductViewModel
    {
        public string Description { get; set; }

        public int AnimalCategoryId { get; set; }

        public virtual AnimalCategoryViewModel AnimalCategory { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderViewModel> Orders { get; set; }
    }
}
