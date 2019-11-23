using Eshop.Domain.Service.BaseService;

namespace Eshop.Domain.Domain
{
    public class ShortProductViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
