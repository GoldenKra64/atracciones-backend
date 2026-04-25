using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Entities
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagDescription { get; set; }
        public ICollection<TagAtraccion> TagAtracciones { get; set; } = new List<TagAtraccion>();
    }
}
