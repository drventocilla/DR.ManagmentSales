
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.InfraestructuraEF
{
    public interface IRepositoryGeneric<T> : IRepositoryAdd<T> , IRepositorySearch<T> , IRepositoryUpdate<T> where T : class
    {
       
    }
}
