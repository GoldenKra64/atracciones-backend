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
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTE");

            builder.HasKey(x => x.CliId);

            builder.Property(x => x.CliTipoIdentificacion)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(x => x.CliNumeroIdentificacion)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.CliCorreo)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.CliTelefono)
                .HasMaxLength(20);

            builder.Property(x => x.CliDireccion)
                .HasMaxLength(300);

            builder.Property(x => x.CliEstado)
                .IsRequired()
                .HasMaxLength(20);

            // 🔥 RowVersion (concurrencia)
            builder.Property(x => x.CliRowVersion)
                .IsRowVersion();

            // 🔥 Relación Usuario
            builder.HasOne(x => x.Usuario)
                .WithMany(u => u.Clientes)
                .HasForeignKey(x => x.UsuId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
