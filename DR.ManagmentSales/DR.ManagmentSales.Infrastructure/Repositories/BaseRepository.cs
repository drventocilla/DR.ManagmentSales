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

        public BaseRepository(DbContext context)
        {
       
            this._dbset = context.Set<T>();

        }

      
        public T Buscar(Expression<Func<T, bool>> filter = null)
        {
            return Consulta(filter).FirstOrDefault();
        }

        public IQueryable<T> Consulta(Expression<Func<T, bool>> filter = null , Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, bool asNoTracking = true)
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
      
        public IEnumerable<T> Listar(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
           return  Consulta(filter , orderBy).AsEnumerable();
        }

        public void Modificar(T entidad)
        {
            _dbset.Update(entidad);
        }

        public void Agregar(T entidad)
        {
            _dbset.Add(entidad);
        }
        public void Eliminar(T entidad)
        {

            _dbset.Remove(entidad);
        }

    }
}
