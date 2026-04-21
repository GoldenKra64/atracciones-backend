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
    public class IncluyeAtraccionConfiguration : IEntityTypeConfiguration<IncluyeAtraccion>
    {
        public void Configure(EntityTypeBuilder<IncluyeAtraccion> builder)
        {
            builder.ToTable("ATRACCION_INCLUYE");

            builder.HasKey(x => new { x.IncId, x.AtId });

            builder.Property(e => e.IncId).HasColumnName("inc_id");
            builder.Property(e => e.AtId).HasColumnName("at_id");

            builder.Property(e => e.AiFechaIngreso).HasColumnName("ai_fecha_ingreso");
            builder.Property(e => e.AiUsuarioIngreso).HasColumnName("ai_usuario_ingreso");

            builder.Property(e => e.AiFechaEliminacion).HasColumnName("ai_fecha_eliminacion");
            builder.Property(e => e.AiUsuarioEliminacion).HasColumnName("ai_usuario_eliminacion");

            builder.Property(e => e.AiEstado).HasColumnName("ai_estado");

            builder.HasOne(x => x.Incluye)
                .WithMany(i => i.IncluyeAtracciones)
                .HasForeignKey(x => x.IncId);

            builder.HasOne(x => x.Atraccion)
                .WithMany()
                .HasForeignKey(x => x.AtId);
        }
    }
}
