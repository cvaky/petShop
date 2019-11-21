using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eshop.Entity.Context;
using Eshop.Entity.Entity;
using Eshop.Entity.Repository;
using Microsoft.EntityFrameworkCore;


namespace Eshop.Entity.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public EshopContext Context { get; }
        private bool disposedValue; // To detect redundant calls
        private Dictionary<Type, object> _repositories;
        public UnitOfWork(EshopContext context)
        {
            Context = context;
            disposedValue = false;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();
            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
                _repositories.Add(type, new Repository<TEntity>(this));
            return (IRepository<TEntity>)_repositories[type];
        }

        public async Task<int> Save()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return -1;
            }
        }

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
