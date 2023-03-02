using Core;
using Core.GestionDeExcepciones;
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
        public async Task<StateExecution> UpdateAsync(Asesor entidad, CancellationToken cancellationToken)
        {
            this._managmentSalesUOW._asesorRepository.Update(entidad);
            await this._managmentSalesUOW.SaveChangesAsync(cancellationToken);

            return (new StateExecution()
            {


                Status = true,
                StateType = State.Ok,
                MessageState = new Message() { Description = "Registro modificado con éxito." },

            });
        }

        public async Task<StateExecution> AddAsync(Asesor entidad, CancellationToken cancellationToken)
        {
            this._managmentSalesUOW._asesorRepository.Add(entidad);
            await this._managmentSalesUOW.SaveChangesAsync(cancellationToken);

            return (new StateExecution()
            {

                Status = true,
                StateType = State.Ok,
                MessageState = new Message() { Description = "Registro guardado con éxito." },

            });
        }

        public async Task<StateExecution>DeleteAsync(string id, CancellationToken cancellationToken)
        {

            Asesor entidad = this._managmentSalesUOW._asesorRepository.Find(x=>x.Id == id);

            if (entidad == null)
            {
                return new StateExecution()
                {


                    Status = false,
                    StateType = State.ErrorNotFound,
                    MessageState = new Message() { Description = "Registro no encontrado." },

                };
            }
            else
            {
               this._managmentSalesUOW._asesorRepository.Delete(entidad);
                await this._managmentSalesUOW.SaveChangesAsync(cancellationToken);
            }
            
            
            

            return new StateExecution()
            {
                Status = true,
                StateType = State.Ok,
                MessageState =  new Message() { Description = "Registro eliminado con éxito." } 

            };
        }

        public  Task<StateExecution<Asesor>> Find(string id, CancellationToken cancellationToken)
        {
            Asesor entidad = this._managmentSalesUOW._asesorRepository.Find(x => x.Id == id);

            return Task.FromResult(new StateExecution<Asesor>()
            {
                Status = true,
                StateType = State.Ok,
                MessageState = new Message() { Description = "Registro encontrado." } ,
                Data = entidad
            });
        }

        public  Task<StateExecution<IEnumerable<Asesor>>> GetAsync(CancellationToken cancellationToken)
        {
            IEnumerable<Asesor> ListaEntidad = this._managmentSalesUOW._asesorRepository.Get();

            return Task.FromResult(new StateExecution<IEnumerable<Asesor>>()
            {
                Status = true,
                StateType = State.Ok,
                MessageState =  new Message() { Description = "Registros encontrados." } ,
                Data = ListaEntidad
            });
        }
    }
}
