using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataManagement.Models.Categoria;
using Atracciones.Backend.DataManagement.Models.Destino;
using Atracciones.Backend.DataManagement.Models.Horario;
using Atracciones.Backend.DataManagement.Models.Imagen;
using Atracciones.Backend.DataManagement.Models.Incluye;
using Atracciones.Backend.DataManagement.Models.NoIncluye;
using Atracciones.Backend.DataManagement.Models.Resena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Models.Atraccion
{
    public class AtraccionTypeModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
