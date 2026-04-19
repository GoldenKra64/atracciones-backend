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
    public class DatosFacturacionConfiguration : IEntityTypeConfiguration<DatosFacturacion>
    {
        public void Configure(EntityTypeBuilder<DatosFacturacion> builder)
        {
            builder.ToTable("DATOS_FACTURACION");

            builder.HasKey(x => x.DfId);

            builder.Property(x => x.DfRazonSocial)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.DfRuc)
                .IsRequired()
                .HasMaxLength(20);

            // 🔥 1:1 con Factura
            builder.HasOne(x => x.Factura)
                .WithOne(f => f.DatosFacturacion)
                .HasForeignKey<DatosFacturacion>(x => x.FacId);
        }
    }
}
