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
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.ToTable("ROLES");

            builder.HasKey(x => x.RolId);

            // 🔗 Columnas
            builder.Property(e => e.RolId).HasColumnName("rol_id");
            builder.Property(e => e.RolGuid).HasColumnName("rol_guid");

            builder.Property(e => e.RolDescripcion)
                   .HasColumnName("rol_descripcion")
                   .HasMaxLength(80);

            builder.Property(e => e.RolFechaIngreso)
                   .HasColumnName("rol_fecha_ingreso");

            builder.Property(e => e.RolUsuarioIngreso)
                   .HasColumnName("rol_usuario_ingreso")
                   .HasMaxLength(100);

            builder.Property(e => e.RolIpIngreso)
                   .HasColumnName("rol_ip_ingreso")
                   .HasMaxLength(45);

            builder.Property(e => e.RolFechaEliminacion)
                   .HasColumnName("rol_fecha_eliminacion");

            builder.Property(e => e.RolUsuarioEliminacion)
                   .HasColumnName("rol_usuario_eliminacion")
                   .HasMaxLength(100);

            builder.Property(e => e.RolIpEliminacion)
                   .HasColumnName("rol_ip_eliminacion")
                   .HasMaxLength(45);

            builder.Property(e => e.RolEstado)
                   .HasColumnName("rol_estado")
                   .HasMaxLength(3);

            builder.HasMany(e => e.UsuarioRoles)
                   .WithOne(ur => ur.Rol)
                   .HasForeignKey(ur => ur.RolId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
