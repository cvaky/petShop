using Eshop.Domain.Service.BaseService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Eshop.Domain.Domain
{
    public class AnimalCategoryViewModel : BaseViewModel
    {
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProductViewModel> Products { get; set; }
    }
}
