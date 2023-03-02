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
        private ManagmentSalesContext _context;

        public IRepositoryGeneric<Asesor> _asesorRepository { get; }
        public IRepositoryGeneric<Producto> _productoRepository { get; }


        public IRepositoryGeneric<DetalleDeVenta> _detalleDeVentaRepository { get; }
        
        public IRepositoryGeneric<Usuario> _usuarioRepository { get; }

        public IVentaRepository _ventaRepository { get; }

        public ManagmentSalesUOW(ManagmentSalesContext context,
                                 IRepositoryGeneric<Usuario> usuarioRepository,
                                 IRepositoryGeneric<Asesor> asesorRepository,
                                 IRepositoryGeneric<Producto> productoRepository,
                                 IRepositoryGeneric<DetalleDeVenta> detalleDeVentaRepository,
                                 IVentaRepository ventaRepository)
        {
            _context = context;
            _usuarioRepository = usuarioRepository;
            _asesorRepository = asesorRepository;
            _productoRepository = productoRepository;
            _detalleDeVentaRepository = detalleDeVentaRepository;
            _ventaRepository = ventaRepository;

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
