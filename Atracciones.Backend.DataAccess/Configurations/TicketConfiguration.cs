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
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("TICKET");

            builder.HasKey(x => x.TicId);

            builder.Property(x => x.TicNombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.TicPrecio)
                .HasColumnType("decimal(10,2)");

            builder.HasOne(x => x.Atraccion)
                .WithMany()
                .HasForeignKey(x => x.AtId);
        }
    }
}
