using AutoMapper;
using Eshop.Domain.Domain;
using Eshop.Entity.Entity;

namespace Eshop.Domain.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            AllowNullCollections = true;
            CreateMap<ProductViewModel, Product>();
            CreateMap<Product, ProductViewModel>();

            CreateMap<OrderViewModel, Order>();
            CreateMap<Order, OrderViewModel>();

            CreateMap<AnimalCategoryViewModel, AnimalCategory>();
            CreateMap<AnimalCategory, AnimalCategoryViewModel>();
        }
    }
}
