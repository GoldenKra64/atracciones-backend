using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Models.Atraccion
{
    public class AtraccionCreateModel
    {
        public int DestinoId { get; set; }

        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }

        public decimal? PrecioReferencia { get; set; }

        public bool IncluyeTransporte { get; set; }
        public bool IncluyeAcompaniante { get; set; }

        public List<int> CategoriaIds { get; set; } = new();
        public List<int> IdiomaIds { get; set; } = new();
        public List<int> IncluyeIds { get; set; } = new();
    }
}
