using AutoMapper;
using Eshop.Domain.Domain;
using Eshop.Domain.Service.BaseService;
using Eshop.Entity.Entity;
using Eshop.Entity.UnitOfWork;


namespace Eshop.Domain.Service
{
    public class AnimalCategoryService<TviewModel, Tentity> : BaseService<TviewModel, Tentity>
                                        where TviewModel : AnimalCategoryViewModel
                                        where Tentity : AnimalCategory
    {
        public AnimalCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
