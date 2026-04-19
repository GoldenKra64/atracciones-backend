using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Models.Factura
{
    public class FacturaModel : BaseModel
    {
        public string Numero { get; set; } = null!;
        public DateTime FechaEmision { get; set; }

        public string OrigenCanal { get; set; } = null!;
        public string? Observacion { get; set; }

        public DatosFacturacionModel DatosFacturacion { get; set; } = null!;
    }
}
