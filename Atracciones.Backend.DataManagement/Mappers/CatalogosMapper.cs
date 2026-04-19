using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataManagement.Models;
using Atracciones.Backend.DataManagement.Models.Categoria;
using Atracciones.Backend.DataManagement.Models.Destino;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Mappers
{
    public static class CatalogosMapper
    {
        public static DestinoModel ToModel(Destino entity)
        {
            return new DestinoModel
            {
                Id = entity.DesId,
                Guid = entity.DesGuid,
                Estado = entity.DesEstado,
                Nombre = entity.DesNombre,
                Pais = entity.DesPais,
                ImagenUrl = entity.DesImagenUrl
            };
        }

        public static CategoriaModel ToModel(Categoria entity)
        {
            return new CategoriaModel
            {
                Id = entity.CatId,
                Guid = entity.CatGuid,
                Estado = entity.CatEstado,
                Nombre = entity.CatNombre,
                ParentId = entity.CatParentId,
                Children = entity.Children?.Select(ToModel).ToList() ?? new()
            };
        }

        public static IdiomaModel ToModel(Idioma entity)
        {
            return new IdiomaModel
            {
                Id = entity.IdiId,
                Nombre = entity.IdiNombre,
                Codigo = entity.IdiCodigo
            };
        }

        public static IncluyeModel ToModel(Incluye entity)
        {
            return new IncluyeModel
            {
                Id = entity.IncId,
                Descripcion = entity.IncDescripcion
            };
        }
        public static void UpdateEntity(Categoria entity, CategoriaUpdateModel model)
        {
            entity.CatNombre = model.Nombre;
            entity.CatParentId = model.ParentId;
        }
        public static void UpdateEntity(Destino entity, DestinoUpdateModel model)
        {
            entity.DesNombre = model.Nombre;
            entity.DesPais = model.Pais;
            entity.DesImagenUrl = model.ImagenUrl;
        }
    }
}
