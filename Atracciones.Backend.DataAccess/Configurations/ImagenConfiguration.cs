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
    public class ImagenConfiguration : IEntityTypeConfiguration<Imagen>
    {
        public void Configure(EntityTypeBuilder<Imagen> builder)
        {
            builder.ToTable("IMAGEN");

            builder.HasKey(x => x.ImgId);

            builder.Property(x => x.ImgUrl)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.ImgDescripcion)
                .HasMaxLength(300);

            builder.Property(x => x.ImgEstado)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(x => x.Atraccion)
                .WithMany(a => a.Imagenes)
                .HasForeignKey(x => x.AtId);
        }
    }
}
