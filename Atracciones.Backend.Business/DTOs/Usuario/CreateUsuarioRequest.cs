using Atracciones.Backend.Business.DTOs.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Usuario
{
    public class CreateUsuarioRequest
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

        public List<int> RolIds { get; set; } = new();

        public CreateClienteRequest Cliente { get; set; } = null!;
    }
}
