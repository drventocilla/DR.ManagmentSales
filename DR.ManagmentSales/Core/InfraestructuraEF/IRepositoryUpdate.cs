
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.InfraestructuraEF
{
    public interface IRepositoryUpdate<T> where T : class
    {
        void Update(T entidad);
        void Delete(T entidad);
    }
}
