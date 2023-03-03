using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.InfraestructuraADO.V1.UnitOfWork
{
    public interface IUnityofWorkAdapter : IDisposable
    {

        void SaveChanges();
        void RollBack();
        Task SaveChangesAsync();
        Task RollBackAsync();
    }
}
