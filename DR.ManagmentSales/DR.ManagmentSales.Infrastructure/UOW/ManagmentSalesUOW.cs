using Core.InfraestructuraADO.V2;
using Core.InfraestructuraEF;
using DR.ManagmentSales.Domain;
using DR.ManagmentSales.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.ManagmentSales.Infrastructure.UOW
{
    public class ManagmentSalesUOW : IManagmentSalesUOW
    {
        private DbContext _context;

        public IRepositoryGeneric<Asesor> AsesorRepository { get; }
        public IRepositoryGeneric<Producto> ProductoRepository { get; }


        public IRepositoryGeneric<DetalleDeVenta> DetalleDeVentaRepository { get; }
        
        public IRepositoryGeneric<Usuario> UsuarioRepository { get; }

        public IVentaRepository VentaRepository { get; }

        public ManagmentSalesUOW(DbContext context )
        {
            _context = context;
        }

       
        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
           return  _context.SaveChangesAsync(cancellationToken);
        }
    }
}
