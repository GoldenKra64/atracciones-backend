using Atracciones.Backend.Business.DTOs.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.Business.DTOs.Atraccion
{
    public class AtraccionDetalleDto
    {
        // 🆔 Identificación
        public Guid Id { get; set; }
        public string Nombre { get; set; }

        // 🌍 Ubicación
        public string Ciudad { get; set; }
        public string Pais { get; set; }

        // 🏷️ Categoría
        public string TipoTagname { get; set; }
        public string TipoNombre { get; set; }
        public string? SubtipoTagname { get; set; }
        public string? SubtipoNombre { get; set; }

        // 🧾 Descripciones
        public string Descripcion { get; set; }
        public string DescripcionCorta { get; set; }

        // 🖼️ Imágenes
        public string ImagenPrincipal { get; set; }
        public List<string> Imagenes { get; set; } = new();

        // 🎁 Incluye / No incluye
        public List<string> Incluye { get; set; } = new();
        public List<string> NoIncluye { get; set; } = new();

        // 📍 Logística
        public string PuntoEncuentro { get; set; }
        public bool IncluyeTransporte { get; set; }
        public bool IncluyeAcompaniante { get; set; }

        // ⏱️ Duración
        public int DuracionMinutos { get; set; }

        // 💰 Precio
        public decimal PrecioDesde { get; set; }
        public string Moneda { get; set; } = "USD";

        // ⭐ Rating
        public decimal Calificacion { get; set; }
        public int TotalResenas { get; set; }

        // 🌍 Idiomas
        public List<string> IdiomasDisponibles { get; set; } = new();

        // 🎟️ Tickets
        public List<TicketDto> Tickets { get; set; } = new();

        // 📦 Disponibilidad (CRÍTICO)
        // public DisponibilidadDto Disponibilidad { get; set; }

        // 🔗 HATEOAS
        public LinksDto Links { get; set; }
    }
}
