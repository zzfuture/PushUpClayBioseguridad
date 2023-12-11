using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ProgramacionConfiguration : IEntityTypeConfiguration<Programacion>
    {
        public void Configure(EntityTypeBuilder<Programacion> builder)
        {
                        builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("programacion");

            builder.HasIndex(e => e.Id, "id").IsUnique();

            builder.HasIndex(e => e.IdContratoFk, "idContratoFk");

            builder.HasIndex(e => e.IdEmpleadoFk, "idEmpleadoFk");

            builder.HasIndex(e => e.IdTurnoFk, "idTurnoFk");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.IdContratoFk).HasColumnName("idContratoFk");
            builder.Property(e => e.IdEmpleadoFk).HasColumnName("idEmpleadoFk");
            builder.Property(e => e.IdTurnoFk).HasColumnName("idTurnoFk");

            builder.HasOne(d => d.IdContratoFkNavigation).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.IdContratoFk)
                .HasConstraintName("programacion_ibfk_1");

            builder.HasOne(d => d.IdEmpleadoFkNavigation).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.IdEmpleadoFk)
                .HasConstraintName("programacion_ibfk_3");

            builder.HasOne(d => d.IdTurnoFkNavigation).WithMany(p => p.Programacions)
                .HasForeignKey(d => d.IdTurnoFk)
                .HasConstraintName("programacion_ibfk_2");
        }
    }
}