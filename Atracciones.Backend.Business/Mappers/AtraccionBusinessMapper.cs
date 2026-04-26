using Atracciones.Backend.Business.DTOs;
using Atracciones.Backend.Business.DTOs.Atraccion;
using Atracciones.Backend.Business.DTOs.Atracciones;
using Atracciones.Backend.Business.DTOs.Horario;
using Atracciones.Backend.Business.DTOs.Ticket;
using Atracciones.Backend.DataAccess.Filters;
using Atracciones.Backend.DataManagement.Models.Atraccion;
using Atracciones.Backend.DataManagement.Models.Resena;
using Atracciones.Backend.DataManagement.Models.Ticket;
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
                DuracionMinutos = request.DuracionMinutos,

                CategoriaIds = request.CategoriaIds,
                IdiomaIds = request.IdiomaIds,
                IncluyeIds = request.IncluyeIds,
                NoIncluyeIds = request.NoIncluyeIds,
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
                DuracionMinutos = request.DuracionMinutos,
                IncluyeAcompaniante = request.IncluyeAcompaniante,
                IncluyeTransporte = request.IncluyeTransporte,
                Moneda = request.Moneda ?? "USD",
                Direccion = request.Direccion,
                PuntoEncuentro = request.PuntoEncuentro,

                CategoriaIds = request.CategoriaIds,
                IdiomaIds = request.IdiomaIds,
                IncluyeIds = request.IncluyeIds,
                NoIncluyeIds = request.NoIncluyeIds,
                // ImageIds = request.ImageIds,
                // HorarioIds = request.HorarioIds
            };
        }

        // 🔹 Model → Response
        /*
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
        */
        public static ListadoAtracciones ToResponse(AtraccionModel model)
        {
            var destinoNombre = model.Destino?.Nombre ?? string.Empty;
            var destinoPais = model.Destino?.Pais ?? string.Empty;

            var resenas = model.Resena ?? new List<ResenaModel>();
            Console.WriteLine("Reseñas: ", resenas);

            var totalResenias = resenas.Count;
            var calificacion = totalResenias > 0 ? resenas.Average(r => r.Calificacion) : 0.0;

            var idiomasDisponibles = model.Idiomas?.Count ?? 0;

            var horarios = model.Horarios ?? new List<Atracciones.Backend.DataManagement.Models.Horario.HorarioModel>();
            var cuposDisponibles = horarios.Sum(h => h?.Cupos ?? 0);
            var disponible = horarios.Any(h => (h?.Cupos ?? 0) > 0);

            DateTime nowDate = DateTime.UtcNow.Date;
            

            var proximaFecha = horarios
                .Where(h => (h?.Cupos ?? 0) > 0)
                .Select(h =>
                {
                    if (DateTime.TryParse(h?.Fecha, out var dt)) return (DateTime?)dt;
                    return null;
                })
                .Where(d => d.HasValue && d.Value >= nowDate)
                .OrderBy(d => d)
                .Select(d => d.Value.ToString("yyyy-MM-dd"))
                .FirstOrDefault();

            var tipoNombre = model.Categorias?.FirstOrDefault()?.Nombre ?? string.Empty;
            var tipoTagname = model.TagAtracciones?.FirstOrDefault()?.Nombre ?? string.Empty;

            var etiquetas = model.TagAtracciones?
                .Select(i => i.Nombre)
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList() ?? new List<string>();

            var imagenPrincipal = model.Imagenes?.FirstOrDefault(i => !string.IsNullOrEmpty(i.Url))?.Url;

            return new ListadoAtracciones
            {
                id = model.Guid ?? string.Empty,
                nombre = model.Nombre ?? string.Empty,
                descripcion_corta = model.Descripcion,
                precio_desde = model.PrecioReferencia,
                moneda = model.Moneda ?? string.Empty,
                ciudad = destinoNombre,
                total_resenias = totalResenias,
                calificacion = calificacion,
                idiomas_disponibles = idiomasDisponibles,
                cupos_disponibles = cuposDisponibles,
                disponible = disponible,
                disponible_hoy = horarios.Any(h =>
                {
                    if (h == null) return false;
                    if ((h.Cupos) <= 0) return false;
                    if (!DateTime.TryParse(h.Fecha, out var dt)) return false;
                    return dt == nowDate;
                }),
                proxima_fecha_disponible = proximaFecha,
                tipo_nombre = tipoNombre,
                tipo_tagname = tipoTagname,
                pais = destinoPais,
                etiquetas = etiquetas,
                duracion_minutos = model.DuracionMinutos ?? 0,
                imagen_principal = imagenPrincipal
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

        public static AtraccionDetalleDto ToResponseDetalle(AtraccionModel model)
        {
            return new AtraccionDetalleDto
            {
                id = model.Guid ?? string.Empty,
                nombre = model.Nombre ?? string.Empty,
                descripcion = model.Descripcion,
                incluye_transporte = model.IncluyeTransporte,
                incluye_acompaniante = model.IncluyeAcompaniante,
                punto_encuentro = model.PuntoEncuentro,
                imagenes = model.Imagenes?.Select(i => i.Url).Where(url => !string.IsNullOrEmpty(url)).ToList() ?? new List<string>(),
                incluye = model.Incluyes?.Select(i => i.Descripcion).Where(s => !string.IsNullOrWhiteSpace(s)).ToList() ?? new List<string>(),
                no_incluye = model.NoIncluyes?.Select(i => i.Descripcion).Where(s => !string.IsNullOrWhiteSpace(s)).ToList() ?? new List<string>(),
                horarios = model.Horarios?.Select(h => new HorarioDto
                {
                    AtraccionId = h.AtraccionId,
                    Cupos = h.Cupos,
                    Fecha = h.Fecha,
                    HoraInicio = h.HoraInicio,
                    HoraFin = h.HoraFin
                }).ToList() ?? new List<HorarioDto>(),
                tickets = model.Horarios?.SelectMany(h => h.Tickets ?? new List<TicketModel>())
                    .Select(t => new TicketDto
                    {
                        TckGuid = t.Guid,
                        Tipo = t.Tipo,
                        Precio = t.Precio,
                        Moneda = model.Moneda ?? "USD"
                    }).ToList() ?? new List<TicketDto>(),
                Links = new LinksDto
                {
                    Self = $"/api/atracciones/{model.Guid}",
                    Listado = $"/api/destinos/{model.Guid}"
                }
            };
        }
    }
}
