using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataManagement.Models.Atraccion;
using Atracciones.Backend.DataManagement.Models.Imagen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataManagement.Mappers
{
    public static class AtraccionMapper
    {
        public static AtraccionModel ToModel(Atraccion entity)
        {
            return new AtraccionModel
            {
                Id = entity.AtId,
                Guid = entity.AtGuid,
                Estado = entity.AtEstado,

                Nombre = entity.AtNombre,
                Descripcion = entity.AtDescripcion,
                Direccion = entity.AtDireccion,
                DuracionMinutos = entity.AtDuracionMinutos,
                PrecioReferencia = entity.AtPrecioReferencia,

                IncluyeAcompaniante = entity.AtIncluyeAcompaniante,
                IncluyeTransporte = entity.AtIncluyeTransporte,

                Destino = entity.Destino != null
                    ? CatalogosMapper.ToModel(entity.Destino)
                    : null!,

                Imagenes = entity.Imagenes?
                    .Select(i => new ImagenModel
                    {
                        Id = i.ImgId,
                        Url = i.ImgUrl,
                        Descripcion = i.ImgDescripcion
                    }).ToList() ?? new(),

                Categorias = entity.CategoriaAtracciones?
                    .Select(ca => CatalogosMapper.ToModel(ca.Categoria))
                    .ToList() ?? new(),

                Idiomas = entity.IdiomaAtracciones?
                    .Select(ia => CatalogosMapper.ToModel(ia.Idioma))
                    .ToList() ?? new(),

                Incluyes = entity.IncluyeAtracciones?
                    .Select(ia => CatalogosMapper.ToModel(ia.Incluye))
                    .ToList() ?? new()
            };
        }

        public static Atraccion ToEntity(AtraccionCreateModel model)
        {
            return new Atraccion
            {
                DesId = model.DestinoId,
                AtNombre = model.Nombre,
                AtDescripcion = model.Descripcion,
                AtPrecioReferencia = model.PrecioReferencia,
                AtIncluyeAcompaniante = model.IncluyeAcompaniante,
                AtIncluyeTransporte = model.IncluyeTransporte,
                AtEstado = "ACT"
            };
        }
        public static void UpdateEntity(Atraccion entity, AtraccionUpdateModel model)
        {
            entity.DesId = model.DestinoId;
            entity.AtNombre = model.Nombre;
            entity.AtDescripcion = model.Descripcion;
            entity.AtPrecioReferencia = model.PrecioReferencia;

            entity.AtIncluyeAcompaniante = model.IncluyeAcompaniante;
            entity.AtIncluyeTransporte = model.IncluyeTransporte;
        }
    }
}
