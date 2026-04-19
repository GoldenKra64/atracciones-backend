using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Models.Destino
{
    public class DestinoModel : BaseModel
    {
        public string Nombre { get; set; } = null!;
        public string Pais { get; set; } = null!;
        public string? ImagenUrl { get; set; }
    }
}
