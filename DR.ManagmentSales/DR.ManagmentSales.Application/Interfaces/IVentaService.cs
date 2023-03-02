using Core;
using DR.ManagmentSales.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.ManagmentSales.Application.Interfaces
{
    public interface IVentaService
    {
        Task<StateExecution> AddAsync(Venta entidad, CancellationToken cancellationToken);
        Task<StateExecution> CancelAsync(string id, CancellationToken cancellationToken);

        Task<StateExecution<IEnumerable<Venta>>> ReportAsync(DateTime FechaInicial , DateTime FechaFinal ,  CancellationToken cancellationToken);

    }
}
