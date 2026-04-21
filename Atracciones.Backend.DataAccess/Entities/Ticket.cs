using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Entities
{
    public class Ticket
    {
        public int TicId { get; set; }
        public Guid TicGuid { get; set; }

        public int AtId { get; set; }

        public string TicTitulo { get; set; } = null!;
        public decimal TicPrecio { get; set; }

        public string TicTipoParticipante { get; set; } = null!;
        public int TicCapacidadMaxima { get; set; }
        public int TicCuposDisponibles { get; set; }

        public DateTime TicFechaIngreso { get; set; }
        public string TicUsuarioIngreso { get; set; } = null!;
        public string TicIpIngreso { get; set; } = null!;

        public DateTime? TicFechaMod { get; set; }
        public string? TicUsuarioMod { get; set; }
        public string? TicIpMod { get; set; }

        public DateTime? TicFechaEliminacion { get; set; }
        public string? TicUsuarioEliminacion { get; set; }
        public string? TicIpEliminacion { get; set; }

        public string TicEstado { get; set; } = null!;

        // Relaciones
        public Atraccion Atraccion { get; set; } = null!;
        public ICollection<DetalleReserva> DetallesReserva { get; set; } = new List<DetalleReserva>();
    }
}
