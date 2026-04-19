using Atracciones.Backend.Business.DTOs.Categoria;
using Atracciones.Backend.Business.DTOs.Destino;
using Atracciones.Backend.Business.DTOs.Idioma;
using Atracciones.Backend.Business.DTOs.Imagen;
using Atracciones.Backend.Business.DTOs.Incluye;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Atracciones
{
    public class AtraccionResponse : BaseResponse
    {
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }

        public decimal? PrecioReferencia { get; set; }

        public bool IncluyeTransporte { get; set; }
        public bool IncluyeAcompaniante { get; set; }

        public DestinoResponse Destino { get; set; } = null!;

        public List<ImagenResponse> Imagenes { get; set; } = new();
        public List<CategoriaResponse> Categorias { get; set; } = new();
        public List<IdiomaResponse> Idiomas { get; set; } = new();
        public List<IncluyeResponse> Incluyes { get; set; } = new();
    }
}
