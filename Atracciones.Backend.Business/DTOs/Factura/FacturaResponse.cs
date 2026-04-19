using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Factura
{
    public class FacturaResponse : BaseResponse
    {
        public string Numero { get; set; } = null!;
        public DateTime FechaEmision { get; set; }

        public string OrigenCanal { get; set; } = null!;

        public DatosFacturacionResponse DatosFacturacion { get; set; } = null!;
    }
}
