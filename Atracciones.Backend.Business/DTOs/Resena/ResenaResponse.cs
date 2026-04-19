using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Resena
{
    public class ResenaResponse
    {
        public int ClienteId { get; set; }
        public int AtraccionId { get; set; }

        public int Calificacion { get; set; }
        public string? Comentario { get; set; }

        public DateTime Fecha { get; set; }
    }
}
