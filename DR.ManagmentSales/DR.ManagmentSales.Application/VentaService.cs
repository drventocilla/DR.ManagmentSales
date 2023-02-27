using Core;
using Core.GestionDeExcepciones;
using Core.Servicios;
using DR.ManagmentSales.Application.Interfaces;
using DR.ManagmentSales.Domain;
using DR.ManagmentSales.Infrastructure.Interface;
using System.Data;

namespace DR.ManagmentSales.Application
{
    public class VentaService : IVentaService
    {
        private IManagmentSalesUOW _managmentSalesUOW;
        public VentaService(IManagmentSalesUOW managmentSalesUOW)
        {
            _managmentSalesUOW = managmentSalesUOW;
        }
        public async Task<EstadoDeEjecucion> AnularAsync(string id , CancellationToken cancellationToken)
        {
            this._managmentSalesUOW.VentaRepository.Anular(id);
            await this._managmentSalesUOW.SaveChangesAsync(cancellationToken);

            return (new EstadoDeEjecucion()
            {
                Status = true,
                TipoEstado = Tipo.Ok,
                Mensajes = new List<Mensaje>() { new Mensaje() { MensajeGenerado = "Registro anulado con éxito." } }

            });
        }

        public async Task<EstadoDeEjecucion> AgregarAsync(Venta entidad, CancellationToken cancellationToken)
        {
            this._managmentSalesUOW.VentaRepository.Agregar(entidad);
            await this._managmentSalesUOW.SaveChangesAsync(cancellationToken);

            return (new EstadoDeEjecucion()
            {
                Status = true,
                TipoEstado = Tipo.Ok,
                Mensajes = new List<Mensaje>() { new Mensaje() { MensajeGenerado = "Registro guardado con éxito." } }

            });
        }

        public Task<EstadoDeEjecucion<IEnumerable<Venta>>> ReporteAsync(DateTime FechaInicial , DateTime FechaFinal ,  CancellationToken cancellationToken)
        {
            IEnumerable<Venta> ListaEntidad = this._managmentSalesUOW.VentaRepository.Listar(x=>x.FechaCreacion >= FechaInicial && x.FechaCreacion <= FechaFinal);

            return Task.FromResult(new EstadoDeEjecucion<IEnumerable<Venta>>()
            {
                Status = true,
                TipoEstado = Tipo.Ok,
                Mensajes = new List<Mensaje>() { new Mensaje() { MensajeGenerado = "Búsqueda realizada con éxito." } },
                ValorObjeto = ListaEntidad
            });
        }

        
    }
}