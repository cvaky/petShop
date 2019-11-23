using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Eshop.Entity.Repository
{
    public static class IncludeExtension 
    {
        public static IQueryable<T> IncludeExt<T>(this DbSet<T> dbSet, params Expression<Func<T, object>>[] includes)
            where T : class
        {
            IQueryable<T> query = null;
            if (includes.Length > 0)
            {
                query = dbSet.Include(includes[0]);
            }
            for (int i = 1; i < includes.Length; i++)
            {
                query = dbSet.Include(includes[i]);
            }
            return query == null ? dbSet : query;
        }
    }
}
