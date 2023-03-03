
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.InfraestructuraADO.V1.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        void GuardarCambios(T entidad);
        void Eliminar(string codigo);
        Task<T> BuscarPorCodigoAsync(string codigo);
        Task<List<T>> ListarTodoAsync();


    }
}
