using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Atraccion
{
    public class AtraccionFilterRequest
    {
        // 🔍 Búsqueda básica
        public string? Nombre { get; set; }

        // 📍 Ubicación
        public int? DestinoId { get; set; }

        // 🏷️ Relacionales
        public List<int>? CategoriaIds { get; set; }
        public List<int>? IdiomaIds { get; set; }

        // 💰 Precio
        public decimal? PrecioMin { get; set; }
        public decimal? PrecioMax { get; set; }

        // ⭐ Extras
        public bool? IncluyeTransporte { get; set; }

        // 📄 Paginación
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
