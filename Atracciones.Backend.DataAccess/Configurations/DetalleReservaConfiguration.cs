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
            builder.ToTable("RESERVA_DETALLE");

            // 🔑 PK
            builder.HasKey(e => e.DetResId);

            // 🔗 Columnas
            builder.Property(e => e.DetResId).HasColumnName("rdet_id");
            builder.Property(e => e.DetResGuid).HasColumnName("rdet_guid");

            builder.Property(e => e.ResId).HasColumnName("rev_id");
            builder.Property(e => e.TicId).HasColumnName("tck_id");

            builder.Property(e => e.DetTitulo).HasColumnName("rdet_titulo");

            builder.Property(e => e.DetCantidad).HasColumnName("rdet_cantidad");
            builder.Property(e => e.DetPrecioUnitario).HasColumnName("rdet_precio_unit");
            builder.Property(e => e.DetSubtotal).HasColumnName("rdet_subtotal");

            builder.HasOne(x => x.Reserva)
                .WithMany(r => r.Detalles)
                .HasForeignKey(x => x.ResId);

            builder.HasOne(x => x.Ticket)
                .WithMany(t => t.DetalleReserva)
                .HasForeignKey(x => x.TicId);
        }
    }
}
