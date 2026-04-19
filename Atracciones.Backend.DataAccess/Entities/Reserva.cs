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

        public int CliId { get; set; }

        public DateTime ResFechaReserva { get; set; }
        public decimal ResTotal { get; set; }

        public string ResEstado { get; set; } = null!;

        public DateTime ResFechaIngreso { get; set; }
        public string ResUsuarioIngreso { get; set; } = null!;
        public string ResIpIngreso { get; set; } = null!;

        public DateTime? ResFechaEliminacion { get; set; }
        public string? ResUsuarioEliminacion { get; set; }
        public string? ResIpEliminacion { get; set; }

        // Relaciones
        public Cliente Cliente { get; set; } = null!;
        public ICollection<DetalleReserva> Detalles { get; set; } = new List<DetalleReserva>();
        public Factura? Factura { get; set; } = new Factura();
    }
}
