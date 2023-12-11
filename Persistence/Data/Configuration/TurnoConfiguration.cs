using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TurnoConfiguration : IEntityTypeConfiguration<Turno>
    {
        public void Configure(EntityTypeBuilder<Turno> builder)
        {
                        builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("turno");

            builder.HasIndex(e => e.Id, "id").IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.HoraFinaliza)
                .HasColumnType("time")
                .HasColumnName("horaFinaliza");
            builder.Property(e => e.HoraInicio)
                .HasColumnType("time")
                .HasColumnName("horaInicio");
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        }
    }
}