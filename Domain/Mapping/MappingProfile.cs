using AutoMapper;
using Eshop.Domain.Domain;
using Eshop.Domain.Service.BaseService;
using Eshop.Entity.Entity;

namespace Eshop.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BaseEntity, BaseViewModel>();
            CreateMap<BaseViewModel, BaseEntity>();

            CreateMap<ShortProductViewModel, Product>();
            CreateMap<Product, ShortProductViewModel>();

            CreateMap<ProductViewModel, Product>();
            CreateMap<Product, ProductViewModel>();

            CreateMap<OrderViewModel, Order>();
            CreateMap<Order, OrderViewModel>();

            CreateMap<AnimalCategoryViewModel, AnimalCategory>();
            CreateMap<AnimalCategory, AnimalCategoryViewModel>();
        }
    }
}
