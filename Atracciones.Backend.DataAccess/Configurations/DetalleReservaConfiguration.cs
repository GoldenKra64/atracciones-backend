using Atracciones.Backend.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atracciones.Backend.DataAccess.Configurations
{
    public class DetalleReservaConfiguration : IEntityTypeConfiguration<DetalleReserva>
    {
        public void Configure(EntityTypeBuilder<DetalleReserva> builder)
        {
            builder.ToTable("DETALLE_RESERVA");

            builder.HasKey(x => x.DetResId);

            builder.Property(x => x.DetPrecioUnitario)
                .HasColumnType("decimal(10,2)");

            builder.Property(x => x.DetSubtotal)
                .HasColumnType("decimal(10,2)");

            builder.HasOne(x => x.Reserva)
                .WithMany(r => r.Detalles)
                .HasForeignKey(x => x.ResId);

            builder.HasOne(x => x.Ticket)
                .WithMany(t => t.DetallesReserva)
                .HasForeignKey(x => x.TicId);
        }
    }
}
