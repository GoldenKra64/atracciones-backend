using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Factura
{
    public class CreateFacturaRequest
    {
        public int ReservaId { get; set; }
        public int ClienteId { get; set; }

        public string Numero { get; set; } = null!;
        public string OrigenCanal { get; set; } = null!;

        public string? Observacion { get; set; }

        public DatosFacturacionRequest DatosFacturacion { get; set; } = null!;
    }
}
