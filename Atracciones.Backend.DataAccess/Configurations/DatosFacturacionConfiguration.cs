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

            builder.HasKey(e => e.DfId);

            builder.Property(e => e.DfId).HasColumnName("dfac_id");
            builder.Property(e => e.DfGuid).HasColumnName("dfac_guid");

            builder.Property(e => e.FacId).HasColumnName("fac_id");

            builder.Property(e => e.DfNombre).HasColumnName("dfac_nombre");
            builder.Property(e => e.DfApellido).HasColumnName("dfac_apellido");
            builder.Property(e => e.DfCorreo).HasColumnName("dfac_correo");
            builder.Property(e => e.DfTelefono).HasColumnName("dfac_telefono");

            // 🔥 1:1 con Factura
            builder.HasOne(x => x.Factura)
                .WithOne(f => f.DatosFacturacion)
                .HasForeignKey<DatosFacturacion>(x => x.FacId);
        }
    }
}
