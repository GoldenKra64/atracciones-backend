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
    public class DestinoConfiguration : IEntityTypeConfiguration<Destino>
    {
        public void Configure(EntityTypeBuilder<Destino> builder)
        {
            builder.ToTable("DESTINO");

            builder.HasKey(x => x.DesId);

            builder.Property(x => x.DesNombre)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(x => x.DesPais)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.DesImagenUrl)
                .HasMaxLength(500);

            builder.Property(x => x.DesEstado)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
