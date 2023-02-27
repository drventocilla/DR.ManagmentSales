
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

        public IRepositoryGeneric<Asesor> AsesorRepository { get; }
        public IRepositoryGeneric<DetalleDeVenta> DetalleDeVentaRepository { get; }
        public IRepositoryGeneric<Producto> ProductoRepository { get; }
        public IRepositoryGeneric<Usuario> UsuarioRepository { get; }
        public IVentaRepository VentaRepository { get; }
    }
}
