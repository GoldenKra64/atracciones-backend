using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Entities
{
    public class Rol
    {
        public int RolId { get; set; }
        public Guid RolGuid { get; set; }

        public string RolDescripcion { get; set; } = null!;

        public DateTime RolFechaIngreso { get; set; }
        public string RolUsuarioIngreso { get; set; } = null!;
        public string RolIpIngreso { get; set; } = null!;

        public DateTime? RolFechaEliminacion { get; set; }
        public string? RolUsuarioEliminacion { get; set; }
        public string? RolIpEliminacion { get; set; }

        public string RolEstado { get; set; } = null!;

        // Relaciones
        public ICollection<UsuarioRol> UsuarioRoles { get; set; } = new List<UsuarioRol>();
    }
}
