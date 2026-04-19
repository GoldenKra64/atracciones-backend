using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Entities
{
    public class Idioma
    {
        public int IdiId { get; set; }

        public string IdiNombre { get; set; } = null!;
        public string IdiCodigo { get; set; } = null!;

        public string IdiEstado { get; set; } = null!;

        public ICollection<IdiomaAtraccion> IdiomaAtracciones { get; set; } = new List<IdiomaAtraccion>();
    }
}
