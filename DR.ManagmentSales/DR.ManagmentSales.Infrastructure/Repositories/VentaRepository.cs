using DR.ManagmentSales.Domain;
using DR.ManagmentSales.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DR.ManagmentSales.Infrastructure.Repositories
{
    public  class VentaRepository : IVentaRepository
    {

        private DbSet<Venta> _dbset;
        private ManagmentSalesContext _context;

        public VentaRepository(ManagmentSalesContext context)
        {
            this._context = context;
            this._dbset = context.Set<Venta>();
        }

        public void Add(Venta entidad)
        {
            _dbset.Add(entidad);
        }

        public void Cancel( string id)
        {
            

        }

        public Venta Find(Expression<Func<Venta, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Venta> Query(Expression<Func<Venta, bool>> filter = null, Func<IQueryable<Venta>, IOrderedQueryable<Venta>> orderBy = null, bool asNoTracking = true)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Venta> Get(Expression<Func<Venta, bool>> filter = null, Func<IQueryable<Venta>, IOrderedQueryable<Venta>> orderBy = null)
        {
            throw new NotImplementedException();
        }
    }
}
