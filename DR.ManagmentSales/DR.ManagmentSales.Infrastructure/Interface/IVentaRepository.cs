using Core.InfraestructuraEF;
using DR.ManagmentSales.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DR.ManagmentSales.Infrastructure.Interface
{
    public interface IVentaRepository : IRepositoryAdd<Venta> , IRepositorySearch<Venta>
    {
       
        void Anular(string id);
    }
}
