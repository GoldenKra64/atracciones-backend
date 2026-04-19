using Atracciones.Backend.Business.DTOs.Categoria;
using Atracciones.Backend.Business.DTOs.Destino;
using Atracciones.Backend.Business.DTOs.Idioma;
using Atracciones.Backend.Business.DTOs.Imagen;
using Atracciones.Backend.Business.DTOs.Incluye;
using Atracciones.Backend.DataManagement.Models;
using Atracciones.Backend.DataManagement.Models.Categoria;
using Atracciones.Backend.DataManagement.Models.Destino;
using Atracciones.Backend.DataManagement.Models.Imagen;
using Atracciones.Backend.DataManagement.Models.Incluye;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Mappers
{
    public static class CatalogosBusinessMapper
    {

        public static CategoriaResponse ToResponse(CategoriaModel model)
        {
            return new CategoriaResponse
            {
                Id = model.Id,
                Guid = model.Guid,
                Nombre = model.Nombre,
                Children = model.Children?.Select(ToResponse).ToList() ?? new()
            };
        }

        public static IdiomaResponse ToResponse(IdiomaModel model)
        {
            return new IdiomaResponse
            {
                Id = model.Id,
                Nombre = model.Nombre
            };
        }

        public static ImagenResponse ToResponse(ImagenModel model)
        {
            return new ImagenResponse
            {
                Id = model.Id,
                Url = model.Url
            };
        }
    }
}
