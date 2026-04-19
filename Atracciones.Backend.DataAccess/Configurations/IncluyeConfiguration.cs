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
    public class IncluyeConfiguration : IEntityTypeConfiguration<Incluye>
    {
        public void Configure(EntityTypeBuilder<Incluye> builder)
        {
            builder.ToTable("INCLUYE");

            builder.HasKey(x => x.IncId);

            builder.Property(x => x.IncDescripcion)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
