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
            builder.ToTable("ROL");

            builder.HasKey(x => x.RolId);

            builder.Property(x => x.RolDescripcion)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.RolEstado)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
