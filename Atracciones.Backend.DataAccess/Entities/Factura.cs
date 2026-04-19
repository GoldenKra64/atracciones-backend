using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Entities
{
    public class Factura
    {
        public int FacId { get; set; }
        public Guid FacGuid { get; set; }

        public int RevId { get; set; }
        public int CliId{ get; set; }

        public string FacNumero { get; set; }
        public DateTime FacFechaEmision { get; set; }
        public string FacObservacion{ get; set; }
        public string FacOrigenCanal{ get; set; }
        public string? FacMotivoInhabilitacion { get; set; }
        public string FacEstado { get; set; }

        public string? FacUsuarioIngreso { get; set; }
        public string? FacIpIngreso { get; set; }
        public DateTime? FacFechaMod { get; set; }
        public string? FacUsuarioMod { get; set; }
        public string? FacIpMod { get; set; }

        public DateTime? FacFechaEliminacion { get; set; }
        public string? FacUsuarioEliminacion { get; set; }
        public string? FacIpEliminacion { get; set; }

        // Relaciones
        public Cliente Cliente { get; set; } = new Cliente();
        public Reserva Reserva { get; set; } = new Reserva();

        public DatosFacturacion DatosFacturacion { get; set; } = new DatosFacturacion();
    }
}
