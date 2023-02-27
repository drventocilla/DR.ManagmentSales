using Core;
using Core.GestionDeExcepciones;
using Core.Servicios;
using DR.ManagmentSales.Domain;
using DR.ManagmentSales.Infrastructure.Interface;

namespace DR.ManagmentSales.Application
{
    public class AsesorService 
    {
        private IManagmentSalesUOW _managmentSalesUOW;
        public AsesorService(IManagmentSalesUOW managmentSalesUOW)
        {
            _managmentSalesUOW = managmentSalesUOW;
        }
        public async Task<EstadoDeEjecucion> ActualizarAsync(Asesor entidad, CancellationToken cancellationToken)
        {
            this._managmentSalesUOW.AsesorRepository.Modificar(entidad);
            await this._managmentSalesUOW.SaveChangesAsync(cancellationToken);

            return (new EstadoDeEjecucion()
            {
                Status = true,
                TipoEstado = Tipo.Ok,
                Mensajes = new List<Mensaje>() { new Mensaje() {    MensajeGenerado ="Registro modificado con éxito."  } }

            });
        }

        public async Task<EstadoDeEjecucion> AgregarAsync(Asesor entidad, CancellationToken cancellationToken)
        {
            this._managmentSalesUOW.AsesorRepository.Agregar(entidad);
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

            Asesor entidad = this._managmentSalesUOW.AsesorRepository.Buscar(x=>x.Id == id);

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
               this._managmentSalesUOW.AsesorRepository.Eliminar(entidad);
                await this._managmentSalesUOW.SaveChangesAsync(cancellationToken);
            }
            
            
            

            return new EstadoDeEjecucion()
            {
                Status = true,
                TipoEstado = Tipo.Ok,
                Mensajes = new List<Mensaje>() { new Mensaje() { MensajeGenerado = "Registro eliminado con éxito." } }

            };
        }

        public  Task<EstadoDeEjecucion<Asesor>> Buscar(string id, CancellationToken cancellationToken)
        {
            Asesor entidad = this._managmentSalesUOW.AsesorRepository.Buscar(x => x.Id == id);

            return Task.FromResult(new EstadoDeEjecucion<Asesor>()
            {
                Status = true,
                TipoEstado = Tipo.Ok,
                Mensajes = new List<Mensaje>() { new Mensaje() { MensajeGenerado = "Registro con encontrado." } },
                ValorObjeto = entidad
            });
        }

        public  Task<EstadoDeEjecucion<IEnumerable<Asesor>>> ListarAsync(CancellationToken cancellationToken)
        {
            IEnumerable<Asesor> ListaEntidad = this._managmentSalesUOW.AsesorRepository.Listar();

            return Task.FromResult(new EstadoDeEjecucion<IEnumerable<Asesor>>()
            {
                Status = true,
                TipoEstado = Tipo.Ok,
                Mensajes = new List<Mensaje>() { new Mensaje() { MensajeGenerado = "Registros encontrados." } },
                ValorObjeto = ListaEntidad
            });
        }
    }
}