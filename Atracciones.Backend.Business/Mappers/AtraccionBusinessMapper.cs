using Atracciones.Backend.Business.DTOs.Atraccion;
using Atracciones.Backend.Business.DTOs.Atracciones;
using Atracciones.Backend.DataAccess.Filters;
using Atracciones.Backend.DataManagement.Models.Atraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.Mappers
{
    public static class AtraccionBusinessMapper
    {
        // 🔹 Request → Model
        public static AtraccionCreateModel ToCreateModel(CreateAtraccionRequest request)
        {
            return new AtraccionCreateModel
            {
                DestinoId = request.DestinoId,
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                PrecioReferencia = request.PrecioReferencia,
                IncluyeAcompaniante = request.IncluyeAcompaniante,
                IncluyeTransporte = request.IncluyeTransporte,
                Moneda = request.Moneda ?? "USD",
                Direccion = request.Direccion,
                PuntoEncuentro = request.PuntoEncuentro,

                CategoriaIds = request.CategoriaIds,
                IdiomaIds = request.IdiomaIds,
                IncluyeIds = request.IncluyeIds,
                TagIds = request.TagIds,
                // ImageIds = request.ImageIds,
                // HorarioIds = request.HorarioIds
            };
        }

        public static AtraccionUpdateModel ToUpdateModel(UpdateAtraccionRequest request)
        {
            return new AtraccionUpdateModel
            {
                Id = request.Id,
                DestinoId = request.DestinoId,
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                PrecioReferencia = request.PrecioReferencia,
                IncluyeAcompaniante = request.IncluyeAcompaniante,
                IncluyeTransporte = request.IncluyeTransporte,
                Moneda = request.Moneda ?? "USD",
                Direccion = request.Direccion,
                PuntoEncuentro = request.PuntoEncuentro,

                CategoriaIds = request.CategoriaIds,
                IdiomaIds = request.IdiomaIds,
                IncluyeIds = request.IncluyeIds,
                // ImageIds = request.ImageIds,
                // HorarioIds = request.HorarioIds
            };
        }

        // 🔹 Model → Response
        public static AtraccionResponse ToResponse(AtraccionModel model)
        {
            return new AtraccionResponse
            {
                Id = model.Id,
                Guid = model.Guid,
                Nombre = model.Nombre,
                Descripcion = model.Descripcion,
                PrecioReferencia = model.PrecioReferencia,
                IncluyeAcompaniante = model.IncluyeAcompaniante,
                IncluyeTransporte = model.IncluyeTransporte,

                Destino = DestinoBusinessMapper.ToResponse(model.Destino),

                Imagenes = model.Imagenes
                    .Select(CatalogosBusinessMapper.ToResponse)
                    .ToList(),

                Categorias = model.Categorias
                    .Select(CatalogosBusinessMapper.ToResponse)
                    .ToList(),

                Idiomas = model.Idiomas
                    .Select(CatalogosBusinessMapper.ToResponse)
                    .ToList(),

                Incluyes = model.Incluyes
                    .Select(IncluyeBusinessMapper.ToResponse)
                    .ToList()
            };
        }
        public static FiltroModel ToFilterModel(FiltroDto request)
        {
            return new FiltroModel
            {
                Page = request.Page,
                Limit = request.Limit,
                Ciudad = request.Ciudad,
                Tipo = request.Tipo,
                Subtipo = request.Subtipo,
                Etiqueta = request.Etiqueta,
                Idioma = request.Idioma,
                CalificacionMin = request.CalificacionMin,
                Horario = request.Horario,
                Disponible = request.Disponible,
                OrdenarPor = request.OrdenarPor
            };
        }
    }
}
