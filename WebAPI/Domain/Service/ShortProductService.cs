using AutoMapper;
using Eshop.Domain.Domain;
using Eshop.Domain.Service.BaseService;
using Eshop.Entity.Entity;
using Eshop.Entity.UnitOfWork;

namespace Eshop.Domain.Service
{
    public class ShortProductService<TviewModel, Tentity> : BaseService<TviewModel, Tentity>
                                        where TviewModel : ShortProductViewModel
                                        where Tentity : Product
    {
        public ShortProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
