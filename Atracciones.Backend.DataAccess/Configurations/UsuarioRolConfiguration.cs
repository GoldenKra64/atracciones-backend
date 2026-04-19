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
    public class UsuarioRolConfiguration : IEntityTypeConfiguration<UsuarioRol>
    {
        public void Configure(EntityTypeBuilder<UsuarioRol> builder)
        {
            builder.ToTable("USUARIO_ROL");

            builder.HasKey(x => x.UsuRolId);

            builder.Property(x => x.UsuRolEstado)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(x => x.Usuario)
                .WithMany(u => u.UsuarioRoles)
                .HasForeignKey(x => x.UsuId);

            builder.HasOne(x => x.Rol)
                .WithMany(r => r.UsuarioRoles)
                .HasForeignKey(x => x.RolId);
        }
    }
}
