using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Entities
{
    public class Ticket
    {
        public int TicId { get; set; }
        public string TicGuid { get; set; }
        public int AtId { get; set; }
        public string TicTitulo { get; set; }
        public decimal TicPrecio { get; set; }
        public string TicTipoParticipante { get; set; }
        public int TicCapacidadMaxima { get; set; }
        public int TicCuposDisponibles { get; set; }

        // Auditoría ingreso
        public DateTime TicFechaIngreso { get; set; }
        public string TicUsuarioIngreso { get; set; }
        public string TicIpIngreso { get; set; }

        // Auditoría modificación
        public DateTime? TicFechaMod { get; set; }
        public string? TicUsuarioMod { get; set; }
        public string? TicIpMod { get; set; }

        // Eliminación lógica
        public DateTime? TicFechaEliminacion { get; set; }
        public string? TicUsuarioEliminacion { get; set; }
        public string? TicIpEliminacion { get; set; }
        public string TicEstado { get; set; }

        // 🔗 Relación con Horario
        public ICollection<Horario> Horarios { get; set; } = new List<Horario>();
        public ICollection<DetalleReserva> DetalleReserva { get; set; } = new List<DetalleReserva>();
        public Atraccion Atraccion { get; set; }
    }
}
