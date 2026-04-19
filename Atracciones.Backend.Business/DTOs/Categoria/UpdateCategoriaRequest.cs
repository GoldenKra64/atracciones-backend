using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Categoria
{
    public class UpdateCategoriaRequest : CreateCategoriaRequest
    {
        public int Id { get; set; }

        public string Estado { get; set; } = null!;
    }
}
