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
    public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.ToTable("FACTURA");

            builder.HasKey(x => x.FacId);

            builder.Property(x => x.FacNumero)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.FacObservacion)
                .HasMaxLength(500);

            builder.Property(x => x.FacOrigenCanal)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.FacEstado)
                .IsRequired()
                .HasMaxLength(20);

            // 🔥 RELACIONES

            builder.HasOne(x => x.Cliente)
                .WithMany()
                .HasForeignKey(x => x.CliId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Reserva)
                .WithOne(r => r.Factura)
                .HasForeignKey<Factura>(x => x.RevId);

            builder.HasOne(x => x.DatosFacturacion)
                .WithOne(df => df.Factura)
                .HasForeignKey<DatosFacturacion>(df => df.FacId);
        }
    }
}
