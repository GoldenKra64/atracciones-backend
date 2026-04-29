using Atracciones.Backend.Business.DTOs.Categoria;
using Atracciones.Backend.Business.DTOs.Destino;
using Atracciones.Backend.Business.DTOs.Idioma;
using Atracciones.Backend.Business.DTOs.Imagen;
using Atracciones.Backend.Business.DTOs.Incluye;
using Atracciones.Backend.Business.DTOs.NoIncluye;
using Atracciones.Backend.Business.DTOs.Tag;
using Atracciones.Backend.DataAccess.Repositories;
using Atracciones.Backend.DataManagement.Models;
using Atracciones.Backend.DataManagement.Models.Categoria;
using Atracciones.Backend.DataManagement.Models.Destino;
using Atracciones.Backend.DataManagement.Models.Incluye;
using Atracciones.Backend.DataManagement.Models.NoIncluye;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Atracciones
{
    public class AtraccionResponse : BaseModel
    {
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string Direccion { get; set; }
        public int? DuracionMinutos { get; set; }
        public double? PrecioReferencia { get; set; }

        public bool IncluyeTransporte { get; set; }
        public bool IncluyeAcompaniante { get; set; }

        public string? PuntoEncuentro { get; set; }
        public string? Moneda { get; set; }

        // Relaciones
        public DestinoResponse Destino { get; set; } = null!;
        public List<CategoriaResponse> Categorias { get; set; } = new();
        public List<IdiomaResponse> Idiomas { get; set; } = new();
        public List<IncluyeResponse> Incluyes { get; set; } = new();
        public List<NoIncluyeResponse> NoIncluyes { get; set; } = new();
        public List<TagResponse> TagAtracciones { get; set; } = new();
    }
}
