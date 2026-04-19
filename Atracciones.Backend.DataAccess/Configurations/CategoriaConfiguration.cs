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
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("CATEGORIA");

            builder.HasKey(x => x.CatId);

            builder.Property(x => x.CatNombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.CatEstado)
                .IsRequired()
                .HasMaxLength(20);

            // 🔥 Self reference (padre-hijo)
            builder.HasOne(x => x.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.CatParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
