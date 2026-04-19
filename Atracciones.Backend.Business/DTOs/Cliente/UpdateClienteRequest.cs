using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Cliente
{
    public class UpdateClienteRequest : CreateClienteRequest
    {
        public int Id { get; set; }
    }
}
