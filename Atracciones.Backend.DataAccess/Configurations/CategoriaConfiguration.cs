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

            builder.Property(e => e.CatId).HasColumnName("cat_id");
            builder.Property(e => e.CatGuid).HasColumnName("cat_guid");

            builder.Property(e => e.CatParentId).HasColumnName("cat_parent_id");
            builder.Property(e => e.CatNombre).HasColumnName("cat_nombre");

            builder.Property(e => e.CatFechaIngreso).HasColumnName("cat_fecha_ingreso");
            builder.Property(e => e.CatUsuarioIngreso).HasColumnName("cat_usuario_ingreso");
            builder.Property(e => e.CatIpIngreso).HasColumnName("cat_ip_ingreso");

            builder.Property(e => e.CatFechaMod).HasColumnName("cat_fecha_mod");
            builder.Property(e => e.CatUsuarioMod).HasColumnName("cat_usuario_mod");
            builder.Property(e => e.CatIpMod).HasColumnName("cat_ip_mod");

            builder.Property(e => e.CatFechaEliminacion).HasColumnName("cat_fecha_eliminacion");
            builder.Property(e => e.CatUsuarioEliminacion).HasColumnName("cat_usuario_eliminacion");
            builder.Property(e => e.CatIpEliminacion).HasColumnName("cat_ip_eliminacion");

            builder.Property(e => e.CatEstado).HasColumnName("cat_estado");

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
