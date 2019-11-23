using Eshop.Domain.Service.BaseService;
using System;

namespace Eshop.Domain.Domain
{
    public class OrderViewModel : BaseViewModel
    {
        public double TotalPrice { get; set; }
        public int ProductCount { get; set; }
        public int ProductId { get; set; }
        public virtual ProductViewModel Product { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
