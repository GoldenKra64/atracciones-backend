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
        public Guid DfGuid { get; set; }

        public int FacId { get; set; }

        public string DfNombre { get; set; } = null!;
        public string DfApellido { get; set; } = null!;
        public string DfCorreo { get; set; } = null!;
        public string? DfTelefono { get; set; }

        public DateTime DfFechaIngreso { get; set; }

        // Navegación
        public Factura Factura { get; set; } = null!;
    }
}
