using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Models.Usuario
{
    public class UsuarioUpdateModel
    {
        public int Id { get; set; }
        public string Login { get; set; } = null!;

        public List<int> RolIds { get; set; } = new List<int>();
    }
}
