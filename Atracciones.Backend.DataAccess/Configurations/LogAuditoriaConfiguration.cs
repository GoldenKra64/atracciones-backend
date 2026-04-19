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
            builder.ToTable("LOG_AUDITORIA");

            builder.HasKey(x => x.LogId);

            builder.Property(x => x.LogTabla)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.LogAccion)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.LogUsuario)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
