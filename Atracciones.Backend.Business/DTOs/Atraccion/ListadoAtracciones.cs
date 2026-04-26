using Atracciones.Backend.Business.DTOs.Categoria;
using Atracciones.Backend.Business.DTOs.Destino;
using Atracciones.Backend.Business.DTOs.Idioma;
using Atracciones.Backend.Business.DTOs.Imagen;
using Atracciones.Backend.Business.DTOs.Incluye;
using Atracciones.Backend.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Atraccion
{
    public class ListadoAtracciones : DisponibilidadDto
    {
        public string id { get; set; } // Guid
        public string nombre { get; set; } = null!;
        public string ciudad { get; set; } = null!;
        public string pais { get; set; } = null!;
        public string tipo_tagname { get; set; } = null!;
        public string tipo_nombre { get; set; } = null!;
        public string? descripcion_corta { get; set; }
        public decimal? precio_desde { get; set; }
        public string moneda { get; set; } = "USD";
        public double calificacion { get; set; }
        public int total_resenias { get; set; }
        public int idiomas_disponibles { get; set; }

        public int duracion_minutos { get; set; }
        public string? imagen_principal { get; set; }
        public List<string> etiquetas { get; set; } = new();
    }
}
