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
    public class IdiomaConfiguration : IEntityTypeConfiguration<Idioma>
    {
        public void Configure(EntityTypeBuilder<Idioma> builder)
        {
            builder.ToTable("IDIOMA");

            builder.HasKey(x => x.IdiId);

            builder.Property(x => x.IdiNombre)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.IdiCodigo)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
