using Eshop.Entity.Context;
using Eshop.Entity.Repository;
using System;
using System.Threading.Tasks;

namespace Eshop.Entity.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        EshopContext Context { get; }
        Task<int> Save();
    }
}
