using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Imagen
{
    public class CreateImagenRequest
    {
        public int AtraccionId { get; set; }
        public string Url { get; set; } = null!;
        public string? Descripcion { get; set; }
    }
}
