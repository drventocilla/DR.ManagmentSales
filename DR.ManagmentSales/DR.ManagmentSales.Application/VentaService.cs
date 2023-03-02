using Core;
using Core.GestionDeExcepciones;
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
        public async Task<StateExecution> CancelAsync(string id , CancellationToken cancellationToken)
        {
            this._managmentSalesUOW._ventaRepository.Cancel(id);
            await this._managmentSalesUOW.SaveChangesAsync(cancellationToken);

            return (new StateExecution()
            {


                Status = true,
                StateType = State.Ok,
                MessageState = new Message() { Description = "Registro anulado con éxito." },


            });
        }

        public async Task<StateExecution> AddAsync(Venta entidad, CancellationToken cancellationToken)
        {
            this._managmentSalesUOW._ventaRepository.Add(entidad);
            await this._managmentSalesUOW.SaveChangesAsync(cancellationToken);

            return (new StateExecution()
            {

                Status = true,
                StateType = State.Ok,
                MessageState = new Message() { Description = "Registro guardado con éxito." },

            });
        }

        public Task<StateExecution<IEnumerable<Venta>>> ReportAsync(DateTime FechaInicial , DateTime FechaFinal ,  CancellationToken cancellationToken)
        {
            IEnumerable<Venta> ListaEntidad = this._managmentSalesUOW._ventaRepository.Get(x=>x.FechaCreacion >= FechaInicial && x.FechaCreacion <= FechaFinal);

            return Task.FromResult(new StateExecution<IEnumerable<Venta>>()
            {
                Status = true,
                StateType = State.Ok,
                MessageState = new Message() { Description = "Búsqueda realizada con éxito." } ,
                Data = ListaEntidad
            });
        }

        
    }
}