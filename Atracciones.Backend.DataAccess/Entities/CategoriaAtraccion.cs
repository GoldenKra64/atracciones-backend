using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Entities
{
    public class CategoriaAtraccion
    {
        public int CatId { get; set; }
        public int AtId { get; set; }

        public DateTime CaFechaIngreso { get; set; }
        public string CaUsuarioIngreso { get; set; } = null!;

        public DateTime? CaFechaEliminacion { get; set; }
        public string? CaUsuarioEliminacion { get; set; }

        public string CaEstado { get; set; } = null!;

        public Categoria Categoria { get; set; } = null!;
        public Atraccion Atraccion { get; set; } = null!;
    }
}
