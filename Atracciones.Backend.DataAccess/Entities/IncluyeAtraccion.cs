using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Entities
{
    public class IncluyeAtraccion
    {
        public int IncId { get; set; }
        public int AtId { get; set; }

        public DateTime AiFechaIngreso { get; set; }
        public string AiUsuarioIngreso { get; set; } = null!;

        public DateTime? AiFechaEliminacion { get; set; }
        public string? AiUsuarioEliminacion { get; set; }

        public string AiEstado { get; set; } = null!;

        // Navegación
        public Incluye Incluye { get; set; } = null!;
        public Atraccion Atraccion { get; set; } = null!;
    }
}
