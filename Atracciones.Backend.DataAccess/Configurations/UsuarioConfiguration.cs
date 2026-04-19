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
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");

            builder.HasKey(x => x.UsuId);

            builder.Property(x => x.UsuLogin)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.UsuPasswordHash)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.UsuEstado)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
