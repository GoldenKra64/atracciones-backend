using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Entities
{
    public class DatosFacturacion
    {
        public int DfId { get; set; }

        public int FacId { get; set; }

        public string DfRazonSocial { get; set; } = null!;
        public string DfRuc { get; set; } = null!;
        public string? DfDireccion { get; set; }

        public DateTime DfFechaIngreso { get; set; }

        // Navegación
        public Factura Factura { get; set; } = null!;
    }
}
