using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Cliente
{
    public class CreateClienteRequest
    {
        public int UsuarioId { get; set; }

        public string TipoIdentificacion { get; set; } = null!;
        public string NumeroIdentificacion { get; set; } = null!;
        public string Correo { get; set; } = null!;
    }
}
