using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Categoria
{
    public class CreateCategoriaRequest
    {
        public string Nombre { get; set; } = null!;
        public int? ParentId { get; set; }
    }
}
