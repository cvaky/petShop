using AutoMapper;
using Eshop.Entity.Entity;
using Eshop.Entity.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Eshop.Domain.Service.BaseService
{
    public class BaseService<TviewModel, Tentity>: IBaseService<TviewModel, Tentity> 
        where TviewModel : BaseViewModel
        where Tentity : BaseEntity
    {
        protected IUnitOfWork _unitOfWork;
        protected IMapper _mapper;
        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public BaseService()
        {

        }

        public virtual async Task<IEnumerable<TviewModel>> GetAll()
        {
            var entities = await _unitOfWork.GetRepository<Tentity>().GetAll();

            return _mapper.Map<IEnumerable<TviewModel>>(entities);
        }

        public virtual async Task<TviewModel> GetSingle(int id, params Expression<Func<Tentity, object>>[] includes)
        {
            var entity = await _unitOfWork.GetRepository<Tentity>().GetSingle(predicate: x => x.Id == id, includes);
            return _mapper.Map<TviewModel>(entity);
        }
        public virtual async Task<IEnumerable<TviewModel>> Get(Expression<Func<Tentity, bool>> predicate)
        {
            var entity = await _unitOfWork.GetRepository<Tentity>().Get(predicate: predicate);
            return _mapper.Map<IEnumerable<TviewModel>>(entity);
        }
        public virtual async Task<int> Add(TviewModel obj)
        {
            var entity = _mapper.Map<Tentity>(obj);
            await _unitOfWork.GetRepository<Tentity>().Insert(entity);
            await _unitOfWork.Save();
            return entity.Id;
        }

        public virtual async Task<int> Update(TviewModel obj)
        {
            var entity = _mapper.Map<Tentity>(obj);
             _unitOfWork.GetRepository<Tentity>().Update(entity);
            await _unitOfWork.Save();
            return entity.Id;
        }
        public virtual async Task<int> Remove(int id)
        {
            await _unitOfWork.GetRepository<Tentity>().Delete(id);
            return await _unitOfWork.Save();
        }
    }
}
