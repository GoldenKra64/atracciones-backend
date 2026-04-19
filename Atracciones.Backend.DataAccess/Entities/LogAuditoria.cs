using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Entities
{
    public class LogAuditoria
    {
        public int LogId { get; set; }

        public string LogTabla { get; set; } = null!;
        public string LogAccion { get; set; } = null!;

        public string? LogValoresAntes { get; set; }
        public string? LogValoresDespues { get; set; }

        public string LogUsuario { get; set; } = null!;
        public DateTime LogFecha { get; set; }

        public string LogIp { get; set; } = null!;
    }
}
