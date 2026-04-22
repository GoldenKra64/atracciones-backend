using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Atracciones.Backend.DataAccess.Entities
{
    public class Atraccion
    {
        public int AtId { get; set; }
        public string AtGuid { get; set; }

        public int DesId { get; set; }

        public string? AtNumEstablecimiento { get; set; }
        public string AtNombre { get; set; } = null!;
        public string? AtDescripcion { get; set; }

        public int AtTotalResenias { get; set; }
        public string? AtDireccion { get; set; }
        public int? AtDuracionMinutos { get; set; }
        public string? AtPuntoEncuentro { get; set; }

        public decimal? AtPrecioReferencia { get; set; }

        public bool AtIncluyeAcompaniante { get; set; }
        public bool AtIncluyeTransporte { get; set; }
        public bool AtDisponible { get; set; }

        public DateTime AtFechaIngreso { get; set; }
        public string AtUsuarioIngreso { get; set; } = null!;
        public string AtIpIngreso { get; set; } = null!;

        public DateTime? AtFechaMod { get; set; }
        public string? AtUsuarioMod { get; set; }
        public string? AtIpMod { get; set; }

        public DateTime? AtFechaEliminacion { get; set; }
        public string? AtUsuarioEliminacion { get; set; }
        public string? AtIpEliminacion { get; set; }

        public string AtEstado { get; set; } = null!;

        // Relaciones
        public Destino Destino { get; set; } = null!;

        public ICollection<Imagen> Imagenes { get; set; } = new List<Imagen>();
        public ICollection<CategoriaAtraccion> CategoriaAtracciones { get; set; } = new List<CategoriaAtraccion>();
        public ICollection<IncluyeAtraccion> IncluyeAtracciones { get; set; } = new List<IncluyeAtraccion>();
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public ICollection<IdiomaAtraccion> IdiomaAtracciones { get; set; } = new List<IdiomaAtraccion>();
    }
}
