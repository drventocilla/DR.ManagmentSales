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
        Task<EstadoDeEjecucion> AgregarAsync(Venta entidad, CancellationToken cancellationToken);
        Task<EstadoDeEjecucion> AnularAsync(string id, CancellationToken cancellationToken);

        Task<EstadoDeEjecucion<IEnumerable<Venta>>> ReporteAsync(DateTime FechaInicial , DateTime FechaFinal ,  CancellationToken cancellationToken);

    }
}
