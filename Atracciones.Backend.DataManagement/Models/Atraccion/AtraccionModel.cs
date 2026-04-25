using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataManagement.Models.Categoria;
using Atracciones.Backend.DataManagement.Models.Destino;
using Atracciones.Backend.DataManagement.Models.Horario;
using Atracciones.Backend.DataManagement.Models.Imagen;
using Atracciones.Backend.DataManagement.Models.Incluye;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Models.Atraccion
{
    public class AtraccionModel : BaseModel
    {
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? Direccion { get; set; }
        public int? DuracionMinutos { get; set; }
        public decimal? PrecioReferencia { get; set; }

        public bool IncluyeTransporte { get; set; }
        public bool IncluyeAcompaniante { get; set; }

        public string? PuntoEncuentro { get; set; }
        public string? Moneda { get; set; }

        // Relaciones
        public DestinoModel Destino { get; set; } = null!;
        public List<ImagenModel> Imagenes { get; set; } = new();
        public List<CategoriaModel> Categorias { get; set; } = new();
        public List<IdiomaModel> Idiomas { get; set; } = new();
        public List<IncluyeModel> Incluyes { get; set; } = new();
        public List<TagAtraccion> TagAtraccions { get; set; } = new();
        public List<HorarioModel> Horarios { get; set; } = new();
    }
}
