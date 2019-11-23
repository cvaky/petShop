using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Eshop.Domain.Service.BaseService
{
    public interface IBaseService<TviewModel, Tentity>
    {
        Task<IEnumerable<TviewModel>> GetAll();
        Task<TviewModel> GetSingle(int id, params Expression<Func<Tentity, object>>[] includes);
        Task<IEnumerable<TviewModel>> Get(Expression<Func<Tentity, bool>> predicate);
        Task<int> Add(TviewModel obj);
        Task<int> Update(TviewModel obj);
        Task<int> Remove(int id);
    }
}
