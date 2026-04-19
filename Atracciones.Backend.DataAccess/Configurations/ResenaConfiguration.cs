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
    public class ResenaConfiguration : IEntityTypeConfiguration<Resena>
    {
        public void Configure(EntityTypeBuilder<Resena> builder)
        {
            builder.ToTable("RESENA");

            builder.HasKey(x => x.ResenaId);

            builder.Property(x => x.ResenaCalificacion)
                .IsRequired();

            builder.Property(x => x.ResenaComentario)
                .HasMaxLength(1000);

            builder.HasOne(x => x.Cliente)
                .WithMany()
                .HasForeignKey(x => x.CliId);

            builder.HasOne(x => x.Atraccion)
                .WithMany()
                .HasForeignKey(x => x.AtId);
        }
    }
}
