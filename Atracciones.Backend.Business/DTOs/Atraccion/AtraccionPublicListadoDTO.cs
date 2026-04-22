using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Atraccion
{
    public class AtraccionListadoDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }

        public string TipoTagname { get; set; }
        public string TipoNombre { get; set; }

        public string? SubtipoTagname { get; set; }
        public string? SubtipoNombre { get; set; }

        public List<string> Etiquetas { get; set; }

        public string DescripcionCorta { get; set; }
        public string ImagenPrincipal { get; set; }

        public int DuracionMinutos { get; set; }

        public decimal PrecioDesde { get; set; }
        public string Moneda { get; set; }

        public decimal Calificacion { get; set; }
        public int TotalResenas { get; set; }

        public List<string> IdiomasDisponibles { get; set; }

        public DisponibilidadDto Disponibilidad { get; set; }

        public object _links { get; set; }
    }
}
