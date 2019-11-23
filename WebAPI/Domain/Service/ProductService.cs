using AutoMapper;
using Eshop.Domain.Domain;
using Eshop.Domain.Service.BaseService;
using Eshop.Entity.Entity;
using Eshop.Entity.UnitOfWork;

namespace Eshop.Domain.Service
{
    public class ProductService<TviewModel, Tentity> : BaseService<TviewModel, Tentity>
                                        where TviewModel : ProductViewModel
                                        where Tentity : Product
    {
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


    }
}
