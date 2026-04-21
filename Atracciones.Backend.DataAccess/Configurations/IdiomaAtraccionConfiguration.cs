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
    public class IdiomaAtraccionConfiguration : IEntityTypeConfiguration<IdiomaAtraccion>
    {
        public void Configure(EntityTypeBuilder<IdiomaAtraccion> builder)
        {
            builder.ToTable("IDIOMA_ATRACCION");

            builder.HasKey(x => new { x.IdId, x.AtId });

            builder.HasOne(x => x.Idioma)
                .WithMany(i => i.IdiomaAtracciones)
                .HasForeignKey(x => x.IdId);

            builder.HasOne(x => x.Atraccion)
                .WithMany()
                .HasForeignKey(x => x.AtId);
        }
    }
}
