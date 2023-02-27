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
        private DbContext _context;

        public VentaRepository(DbContext context)
        {
            this._context = context;
            this._dbset = context.Set<Venta>();
        }

        public void Agregar(Venta entidad)
        {
            _dbset.Add(entidad);
        }

        public void Anular( string id)
        {
            Venta venta = new Venta();
            venta.Id = id;
            venta.EstadoActual = Estado.Valido;

            _context.Attach(venta);
            _context.Entry(venta).Property("EstadoActual").IsModified = true;

        }

        public Venta Buscar(Expression<Func<Venta, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Venta> Consulta(Expression<Func<Venta, bool>> filter = null, Func<IQueryable<Venta>, IOrderedQueryable<Venta>> orderBy = null, bool asNoTracking = true)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Venta> Listar(Expression<Func<Venta, bool>> filter = null, Func<IQueryable<Venta>, IOrderedQueryable<Venta>> orderBy = null)
        {
            throw new NotImplementedException();
        }
    }
}
