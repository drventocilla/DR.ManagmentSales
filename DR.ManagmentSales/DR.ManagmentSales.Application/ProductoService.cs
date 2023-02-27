using Core;
using Core.GestionDeExcepciones;
using Core.Servicios;
using DR.ManagmentSales.Domain;
using DR.ManagmentSales.Infrastructure.Interface;

namespace DR.ManagmentSales.Application
{
    public class ProductoService : IServicio<Producto>
    {
        private IManagmentSalesUOW _managmentSalesUOW;
        public ProductoService(IManagmentSalesUOW managmentSalesUOW)
        {
            _managmentSalesUOW = managmentSalesUOW;
        }
        public async Task<EstadoDeEjecucion> ActualizarAsync(Producto entidad, CancellationToken cancellationToken)
        {
            this._managmentSalesUOW.ProductoRepository.Modificar(entidad);
            await this._managmentSalesUOW.SaveChangesAsync(cancellationToken);

            return (new EstadoDeEjecucion()
            {
                Status = true,
                TipoEstado = Tipo.Ok,
                Mensajes = new List<Mensaje>() { new Mensaje() { MensajeGenerado = "Registro modificado con éxito." } }

            });
        }

        public async Task<EstadoDeEjecucion> AgregarAsync(Producto entidad, CancellationToken cancellationToken)
        {
            this._managmentSalesUOW.ProductoRepository.Agregar(entidad);
            await this._managmentSalesUOW.SaveChangesAsync(cancellationToken);

            return (new EstadoDeEjecucion()
            {
                Status = true,
                TipoEstado = Tipo.Ok,
                Mensajes = new List<Mensaje>() { new Mensaje() { MensajeGenerado = "Registro guardado con éxito." } }

            });
        }

        public async Task<EstadoDeEjecucion> EliminarAsync(string id, CancellationToken cancellationToken)
        {

            Producto entidad = this._managmentSalesUOW.ProductoRepository.Buscar(x => x.Id == id);

            if (entidad == null)
            {
                return new EstadoDeEjecucion()
                {
                    Status = true,
                    TipoEstado = Tipo.ErrorDeRecursoNoEncontrado,
                    Mensajes = new List<Mensaje>() { new Mensaje() { MensajeGenerado = "Registro no encontrado." } }

                };
            }
            else
            {
                this._managmentSalesUOW.ProductoRepository.Eliminar(entidad);
                await this._managmentSalesUOW.SaveChangesAsync(cancellationToken);
            }




            return new EstadoDeEjecucion()
            {
                Status = true,
                TipoEstado = Tipo.Ok,
                Mensajes = new List<Mensaje>() { new Mensaje() { MensajeGenerado = "Registro eliminado con éxito." } }

            };
        }

        public Task<EstadoDeEjecucion<Producto>> Buscar(string id, CancellationToken cancellationToken)
        {
            Producto entidad = this._managmentSalesUOW.ProductoRepository.Buscar(x => x.Id == id);

            return Task.FromResult(new EstadoDeEjecucion<Producto>()
            {
                Status = true,
                TipoEstado = Tipo.Ok,
                Mensajes = new List<Mensaje>() { new Mensaje() { MensajeGenerado = "Registro con encontrado." } },
                ValorObjeto = entidad
            });
        }

        public Task<EstadoDeEjecucion<IEnumerable<Producto>>> ListarAsync(CancellationToken cancellationToken)
        {
            IEnumerable<Producto> ListaEntidad = this._managmentSalesUOW.ProductoRepository.Listar();

            return Task.FromResult(new EstadoDeEjecucion<IEnumerable<Producto>>()
            {
                Status = true,
                TipoEstado = Tipo.Ok,
                Mensajes = new List<Mensaje>() { new Mensaje() { MensajeGenerado = "Registros encontrados." } },
                ValorObjeto = ListaEntidad
            });
        }
    }
}
