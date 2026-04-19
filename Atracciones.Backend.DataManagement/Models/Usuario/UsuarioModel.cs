using Atracciones.Backend.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Models.Usuario
{
    public class UsuarioModel : BaseModel
    {
        public string Login { get; set; } = null!;
        public List<string> Roles { get; set; } = new List<string>();
    }
}
