using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Factura
{
    public class DatosFacturacionRequest
    {
        public string RazonSocial { get; set; } = null!;
        public string Ruc { get; set; } = null!;
        public string? Direccion { get; set; }
    }
}
