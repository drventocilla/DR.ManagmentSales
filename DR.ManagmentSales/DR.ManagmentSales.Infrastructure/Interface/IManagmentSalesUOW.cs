
using Core.InfraestructuraADO.V2;
using Core.InfraestructuraEF;
using DR.ManagmentSales.Domain;
using DR.ManagmentSales.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.ManagmentSales.Infrastructure.Interface
{
    public interface IManagmentSalesUOW : IUnityOfWork
    {

        public IRepositoryGeneric<Asesor> _asesorRepository { get; }
        public IRepositoryGeneric<DetalleDeVenta> _detalleDeVentaRepository { get; }
        public IRepositoryGeneric<Producto> _productoRepository { get; }
        public IRepositoryGeneric<Usuario> _usuarioRepository { get; }
        public IVentaRepository _ventaRepository { get; }
    }
}
