using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Services

{
    public interface IServicio<T> where T : class 
    {
        Task<StateExecution> AddAsync(T entidad , CancellationToken cancellationToken);
        Task<StateExecution> DeleteAsync(string id, CancellationToken cancellationToken);

        Task<StateExecution> UpsertAsync(T entidad, CancellationToken cancellationToken);

        Task<StateExecution<T>> FindAsync(string id, CancellationToken cancellationToken);
        Task<StateExecution<IEnumerable<T>>> GetAsync( CancellationToken cancellationToken);
        
    }
}
