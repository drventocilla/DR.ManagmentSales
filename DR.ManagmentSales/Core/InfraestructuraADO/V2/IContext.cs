using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.InfraestructuraADO.V2
{
    public interface IContext : IDisposable
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);
        void SaveChanges();
        Task RollbackAsync();
        void Rollback();

    }
}
