using Core.GestionDeExcepciones;
using Core;
using DR.ManagmentSales.Domain;
using DR.ManagmentSales.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Seguridad.Cifrado;

namespace DR.ManagmentSales.Application
{
    public class UsuarioService
    {
        private readonly IManagmentSalesUOW _managmentSalesUOW;
        public UsuarioService(IManagmentSalesUOW managmentSalesUOW)
        {
            _managmentSalesUOW = managmentSalesUOW;
        }

        public async Task<StateExecution> UpdateAsync(Usuario entidad, CancellationToken cancellationToken)
        {
            this._managmentSalesUOW._usuarioRepository.Update(entidad);
            await this._managmentSalesUOW.SaveChangesAsync(cancellationToken);

            return (new StateExecution()
            {
                Status = true,
                StateType = State.Ok,
                MessageState = new Message() { Description = "Registro modificado con éxito." },


            });
        }

        public async Task<StateExecution> AddAsync(Usuario entidad, CancellationToken cancellationToken)
        {
            this._managmentSalesUOW._usuarioRepository.Add(entidad);
            await this._managmentSalesUOW.SaveChangesAsync(cancellationToken);

            return (new StateExecution()
            {

                Status = true,
                StateType = State.Ok,
                MessageState = new Message() { Description = "Registro guardado con éxito." },


            });
        }


        public async Task<StateExecution<Usuario>> VerifySignIn(string login , string password)
        {
            Usuario usuario =  this._managmentSalesUOW._usuarioRepository.Find(x => x.Login == login);

            IEnumerable<Usuario> listaUsuario = this._managmentSalesUOW._usuarioRepository.Get();

            if (usuario== null)
            {
                return (new StateExecution<Usuario>()
                {
                    Status = false,
                    StateType = State.ErrorNotFound,
                    MessageState = new Message() { Description = "Usuario no existe." },
                    
                });
            }


            if (usuario.Password == Hash_IIT.Encrypt(password,"2"))
            {
                return (new StateExecution<Usuario>()
                {
                    Status = true,
                    StateType = State.ErrorNotFound,
                    MessageState = new Message() { Description = "Session Validada." },
                    Data = usuario
                });
            }
            else
            {
                return (new StateExecution<Usuario>()
                {
                    Status = false,
                    StateType = State.ErrorValidation,
                    MessageState = new Message() { Description = "Credenciales incorrectos." },

                });
            }
                      

          
        }

        public async Task<StateExecution> DeleteAsync(string id, CancellationToken cancellationToken)
        {

            Usuario entidad = this._managmentSalesUOW._usuarioRepository.Find(x => x.Id == id);

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
                this._managmentSalesUOW._usuarioRepository.Delete(entidad);
                await this._managmentSalesUOW.SaveChangesAsync(cancellationToken);
            }




            return new StateExecution()
            {

                Status = true,
                StateType = State.Ok,
                MessageState = new Message() { Description = "Registro eliminado con éxito." },

            };
        }

        public Task<StateExecution<Usuario>> Buscar(string id, CancellationToken cancellationToken)
        {
            Usuario entidad = this._managmentSalesUOW._usuarioRepository.Find(x => x.Id == id);

            return Task.FromResult(new StateExecution<Usuario>()
            {
                Status = true,
                StateType = State.Ok,
                MessageState = new Message() { Description = "Registro encontrado." },
                Data = entidad

            });
        }

        public Task<StateExecution<IEnumerable<Usuario>>> ListarAsync(CancellationToken cancellationToken)
        {
            IEnumerable<Usuario> ListaEntidad = this._managmentSalesUOW._usuarioRepository.Get();

            return Task.FromResult(new StateExecution<IEnumerable<Usuario>>()
            {

                Status = true,
                StateType = State.Ok,
                MessageState = new Message() { Description = "Registros encontrados." },
                Data = ListaEntidad
               
            });
        }
    }

}

