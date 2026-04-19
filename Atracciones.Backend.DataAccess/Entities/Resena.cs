using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Entities
{
    public class Resena
    {
        public int ResenaId { get; set; }
        public Guid ResenaGuid { get; set; }

        public int CliId { get; set; }
        public int AtId { get; set; }

        public int ResenaCalificacion { get; set; }
        public string? ResenaComentario { get; set; }

        public DateTime ResenaFecha { get; set; }

        public string ResenaEstado { get; set; } = null!;

        // Navegación
        public Cliente Cliente { get; set; } = null!;
        public Atraccion Atraccion { get; set; } = null!;
    }
}
