using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Entities
{
    public class Reserva
    {
        public int ResId { get; set; }
        public Guid ResGuid { get; set; }

        public string ResCodigo { get; set; } = null!;

        public int CliId { get; set; }

        public DateTime ResFechaReservaUtc { get; set; }

        public decimal ResSubtotal { get; set; }
        public decimal ResValorIva { get; set; }
        public decimal ResTotal { get; set; }

        public string? ResOrigenCanal { get; set; }

        public string ResUsuarioIngreso { get; set; } = null!;
        public string ResIpIngreso { get; set; } = null!;

        public DateTime? ResFechaMod { get; set; }
        public string? ResUsuarioMod { get; set; }
        public string? ResIpMod { get; set; }

        public DateTime? ResFechaCancelacion { get; set; }
        public string? ResUsuarioCancelacion { get; set; }
        public string? ResIpCancelacion { get; set; }
        public string? ResMotivoCancelacion { get; set; }

        public string ResEstado { get; set; } = null!;

        // Relaciones
        public Cliente Cliente { get; set; } = null!;
        public ICollection<DetalleReserva> Detalles { get; set; } = new List<DetalleReserva>();
        public ICollection<Resena> Resenas { get; set; } = new List<Resena>();
        public Factura? Factura { get; set; }
    }
}
