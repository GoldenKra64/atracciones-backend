using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Entities
{
    public class Categoria
    {
        public int CatId { get; set; }
        public string CatGuid { get; set; }

        public int? CatParentId { get; set; }
        public string CatNombre { get; set; } = null!;

        public DateTime CatFechaIngreso { get; set; }
        public string CatUsuarioIngreso { get; set; } = null!;
        public string CatIpIngreso { get; set; } = null!;

        public DateTime? CatFechaMod { get; set; }
        public string? CatUsuarioMod { get; set; }
        public string? CatIpMod { get; set; }

        public DateTime? CatFechaEliminacion { get; set; }
        public string? CatUsuarioEliminacion { get; set; }
        public string? CatIpEliminacion { get; set; }

        public string CatEstado { get; set; } = null!;

        // 🔥 Self reference
        public Categoria? Parent { get; set; }
        public ICollection<Categoria> Children { get; set; } = new List<Categoria>();

        public ICollection<CategoriaAtraccion> CategoriaAtracciones { get; set; } = new List<CategoriaAtraccion>();
    }
}
