using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Entities
{
    public class LogAuditoria
    {
        public long LogId { get; set; }
        public string LogGuid { get; set; }

        public string LogTabla { get; set; } = null!;
        public string LogOperacion { get; set; } = null!;

        public int? LogRegistroId { get; set; }
        public string? LogRegistroGuid { get; set; }

        public string? LogDatosAnteriores { get; set; }
        public string? LogDatosNuevos { get; set; }

        public DateTime LogFechaUtc { get; set; }
        public string LogUsuario { get; set; } = null!;
        public string LogIp { get; set; } = null!;

        public string? LogOrigenCanal { get; set; }
    }
}
