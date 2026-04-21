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
    public class LogAuditoriaConfiguration : IEntityTypeConfiguration<LogAuditoria>
    {
        public void Configure(EntityTypeBuilder<LogAuditoria> builder)
        {
            builder.ToTable("AUDITORIA_LOG");

            builder.HasKey(e => e.LogId);

            builder.Property(e => e.LogId).HasColumnName("log_id");
            builder.Property(e => e.LogGuid).HasColumnName("log_guid");

            builder.Property(e => e.LogTabla)
                   .HasColumnName("log_tabla")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.LogOperacion)
                   .HasColumnName("log_operacion")
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(e => e.LogRegistroId)
                   .HasColumnName("log_registro_id");

            builder.Property(e => e.LogRegistroGuid)
                   .HasColumnName("log_registro_guid");

            builder.Property(e => e.LogDatosAnteriores)
                   .HasColumnName("log_datos_anteriores");

            builder.Property(e => e.LogDatosNuevos)
                   .HasColumnName("log_datos_nuevos");

            builder.Property(e => e.LogFechaUtc)
                   .HasColumnName("log_fecha_utc");

            builder.Property(e => e.LogUsuario)
                   .HasColumnName("log_usuario")
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.LogIp)
                   .HasColumnName("log_ip")
                   .HasMaxLength(45)
                   .IsRequired();

            builder.Property(e => e.LogOrigenCanal)
                   .HasColumnName("log_origen_canal")
                   .HasMaxLength(200);
        }
    }
}
