using Atracciones.Backend.DataAccess.Common;
using Atracciones.Backend.DataAccess.Context;
using Atracciones.Backend.DataAccess.Entities;
using Atracciones.Backend.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Repositories
{
    public class ReservaRepository : Repository<Reserva>, IReservaRepository
    {
        public ReservaRepository(AtraccionesDbContext context) : base(context) { }

        public async Task<int> CreateWithDetallesAsync(Reserva reserva)
        {
            await _context.Reservas.AddAsync(reserva);
            await _context.SaveChangesAsync();
            return reserva.ResId;
        }

        public override async Task SoftDeleteAsync(int id)
        {
            var reserva = await _context.Reservas
                .Include(r => r.Detalles)
                .FirstOrDefaultAsync(r => r.ResId == id);

            if (reserva == null) return;

            // 🔥 Cabecera
            StatusChange.SetEstado(reserva, "ANU");

            // 🔥 Detalles
            foreach (var det in reserva.Detalles)
            {
                // si tienes estado en detalle
                var prop = det.GetType().GetProperty("Estado");
                prop?.SetValue(det, "ANU");
            }

            await _context.SaveChangesAsync();
        }
    }
}
