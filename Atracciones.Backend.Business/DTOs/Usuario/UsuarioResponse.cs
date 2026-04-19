using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Usuario
{
    public class UsuarioResponse
    {
        public string Login { get; set; } = null!;

        public List<string> Roles { get; set; } = new();
    }
}
