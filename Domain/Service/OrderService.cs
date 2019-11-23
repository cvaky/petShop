using AutoMapper;
using Eshop.Domain.Domain;
using Eshop.Domain.Service.BaseService;
using Eshop.Entity.Entity;
using Eshop.Entity.UnitOfWork;

namespace Eshop.Domain.Service
{
    public class OrderService<TviewModel, Tentity> : BaseService<TviewModel, Tentity>
                                        where TviewModel : OrderViewModel
                                        where Tentity : Order
    {
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
