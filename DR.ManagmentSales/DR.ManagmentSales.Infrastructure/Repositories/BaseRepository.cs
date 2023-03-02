using Core.InfraestructuraEF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DR.ManagmentSales.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepositoryGeneric<T>  where T : class
    {
              
        private DbSet<T> _dbset;

        public BaseRepository(ManagmentSalesContext context)
        {
       
            this._dbset = context.Set<T>();

        }

      
        public T Find(Expression<Func<T, bool>> filter = null)
        {
            return Query(filter).FirstOrDefault();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter = null , Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool asNoTracking = true)
        {
            IQueryable<T> query = asNoTracking?  this._dbset.AsNoTracking() : this._dbset;

            if (filter != null)
            {
                query.Where(filter);
            }

            if (orderBy != null) {

                return orderBy(query);
            }

            return query;
                
        }
      
        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            return _dbset.ToList();
        }

        public void Update(T entidad)
        {
            _dbset.Update(entidad);
        }

        public void Add(T entidad)
        {
            _dbset.Add(entidad);
        }
        public void Delete(T entidad)
        {

            _dbset.Remove(entidad);
        }

    }
}
