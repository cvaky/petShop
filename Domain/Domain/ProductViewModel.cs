using Eshop.Domain.Service.BaseService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eshop.Domain.Domain
{
    public class ProductViewModel: BaseViewModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public int AnimalCategoryId { get; set; }

        [JsonIgnore]
        public virtual AnimalCategoryViewModel AnimalCategory { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderViewModel> Orders { get; set; }
    }
}
