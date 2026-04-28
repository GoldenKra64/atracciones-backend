using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataManagement.Models.Atraccion;
using Atracciones.Backend.DataManagement.Models.Horario;
using Atracciones.Backend.DataManagement.Models.Imagen;
using Atracciones.Backend.DataManagement.Models.Resena;
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
                PuntoEncuentro = entity.AtPuntoEncuentro,
                Moneda = entity.AtMoneda,

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
                    .Where(ia => ia.Incluye != null)
                    .Select(ia => CatalogosMapper.ToModel(ia.Incluye))
                    .ToList() ?? new(),

                NoIncluyes = entity.NoIncluyeAtracciones?
                    .Where(ia => ia.NoIncluye != null)
                    .Select(ia => CatalogosMapper.ToModel(ia.NoIncluye))
                    .ToList() ?? new(),

                Horarios = entity.Horario?
                    .Select(ia => new HorarioModel
                    {
                        HorarioId = ia.HorId,
                        HorarioGuid = ia.HorGuid,
                        AtraccionId = ia.AtId,
                        Fecha = ia.HorFecha.ToString("yyyy-MM-dd"),
                        HoraInicio = ia.HorHoraInicio.ToString(@"hh\:mm"),
                        HoraFin = ia.HorHoraFin?.ToString(@"hh\:mm"),
                        Cupos = ia.HorCuposDisponibles,
                        Tickets = ia.Ticket?.Select(TicketMapper.ToModel).ToList() ?? new()
                    }).ToList() ?? new(),

                TagAtracciones = entity.TagAtracciones?
                    .Where(ta => ta.Tag != null)
                    .Select(ta => CatalogosMapper.ToModel(ta.Tag))
                    .ToList() ?? new(),

                Resena = entity.Resena?
                    .Select(r => new ResenaModel
                    {
                        AtraccionId = r.AtId,
                        Comentario = r.ResenaComentario,
                        Calificacion = r.ResenaCalificacion,
                        Fecha = r.ResenaFechaCreacion.ToShortDateString(),
                        ClienteId = r.CliId
                    }).ToList() ?? new(),
            };
        }

        public static Atraccion ToEntity(AtraccionCreateModel model)
        {
            var entity = new Atraccion
            {
                DesId = model.DestinoId,
                AtNombre = model.Nombre,
                AtGuid = Guid.NewGuid().ToString(),
                AtDescripcion = model.Descripcion,
                AtPrecioReferencia = model.PrecioReferencia,
                AtIncluyeAcompaniante = model.IncluyeAcompaniante,
                AtIncluyeTransporte = model.IncluyeTransporte,
                AtFechaIngreso = DateTime.UtcNow,
                AtUsuarioIngreso = "system", // En un escenario real, esto debería ser el usuario autenticado
                AtIpIngreso = "127.0.0.1", // En un escenario real, esto debería ser la IP del cliente
                AtEstado = "ACT",
            };

            entity.CategoriaAtracciones = (model.CategoriaIds ?? Enumerable.Empty<int>()).Select(cateId => new CategoriaAtraccion { CatId = cateId, Atraccion = entity }).ToList();
            entity.IncluyeAtracciones = (model.IncluyeIds ?? Enumerable.Empty<int>()).Select(incId => new IncluyeAtraccion { IncId = incId, Atraccion = entity }).ToList();
            entity.IdiomaAtracciones = (model.IdiomaIds ?? Enumerable.Empty<int>()).Select(idiId => new IdiomaAtraccion { IdId = idiId, Atraccion = entity }).ToList();
            entity.NoIncluyeAtracciones = (model.NoIncluyeIds ?? Enumerable.Empty<int>()).Select(noIncId => new NoIncluyeAtraccion { NoIncId = noIncId, Atraccion = entity }).ToList();
            return entity;
        }
        public static void UpdateEntity(Atraccion entity, AtraccionUpdateModel model)
        {
            entity.DesId = model.DestinoId;
            entity.AtNombre = model.Nombre;
            entity.AtDescripcion = model.Descripcion;
            entity.AtPrecioReferencia = model.PrecioReferencia;

            entity.AtIncluyeAcompaniante = model.IncluyeAcompaniante;
            entity.AtIncluyeTransporte = model.IncluyeTransporte;

            entity.CategoriaAtracciones = (model.CategoriaIds ?? Enumerable.Empty<int>())
                .Select(cateId => new CategoriaAtraccion { CatId = cateId, AtId = entity.AtId })
                .ToList();

            entity.IncluyeAtracciones = (model.IncluyeIds ?? Enumerable.Empty<int>())
                .Select(incId => new IncluyeAtraccion { IncId = incId, AtId = entity.AtId })
                .ToList();

            entity.IdiomaAtracciones = (model.IdiomaIds ?? Enumerable.Empty<int>())
                .Select(idiId => new IdiomaAtraccion { IdId = idiId, AtId = entity.AtId })
                .ToList();

            entity.NoIncluyeAtracciones = (model.NoIncluyeIds ?? Enumerable.Empty<int>())
                .Select(noIncId => new NoIncluyeAtraccion { NoIncId = noIncId, AtId = entity.AtId })
                .ToList();
        }

        public static AtraccionTypeModel ToTypeModel(Atraccion atraccion)
        {
            return new AtraccionTypeModel
            {
                Id = atraccion.AtId,
                Nombre = atraccion.AtNombre
            };
        }
    }
}
