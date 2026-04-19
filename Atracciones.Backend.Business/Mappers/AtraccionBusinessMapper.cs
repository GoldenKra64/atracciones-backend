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

                CategoriaIds = request.CategoriaIds,
                IdiomaIds = request.IdiomaIds,
                IncluyeIds = request.IncluyeIds
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

                CategoriaIds = request.CategoriaIds,
                IdiomaIds = request.IdiomaIds,
                IncluyeIds = request.IncluyeIds
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
        public static AtraccionFilterModel ToFilterModel(AtraccionFilterRequest request)
        {
            return new AtraccionFilterModel
            {
                Nombre = request.Nombre,
                DestinoId = request.DestinoId,
                CategoriaIds = request.CategoriaIds,
                IdiomaIds = request.IdiomaIds,
                PrecioMin = request.PrecioMin,
                PrecioMax = request.PrecioMax,
                IncluyeTransporte = request.IncluyeTransporte,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }
    }
}
