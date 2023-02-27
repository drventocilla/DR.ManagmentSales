using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.ManagmentSales.Domain
{
    public class Auditoria
    {
        public string CreadoPorID { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ModificadoPorID { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
