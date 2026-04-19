using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Entities
{
    public class Incluye
    {
        public int IncId { get; set; }
        public Guid IncGuid { get; set; }

        public string IncDescripcion { get; set; } = null!;

        public string IncEstado { get; set; } = null!;

        public ICollection<IncluyeAtraccion> IncluyeAtracciones { get; set; } = new List<IncluyeAtraccion>();
    }
}
