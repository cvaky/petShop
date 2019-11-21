using Eshop.Domain.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eshop.Domain.Domain
{
    public class OrderViewModel : BaseViewModel
    {
        public double TotalPrice { get; set; }
        public virtual ProductViewModel Product { get; set; }
        public int ProductCount { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
