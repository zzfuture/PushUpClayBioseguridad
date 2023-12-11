using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("contrato");

            builder.HasIndex(e => e.Id, "id").IsUnique();

            builder.HasIndex(e => e.IdClienteFk, "idClienteFk");

            builder.HasIndex(e => e.IdEmpleadoFk, "idEmpleadoFk");

            builder.HasIndex(e => e.IdEstadoFk, "idEstadoFk");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.FechaContrato).HasColumnName("fechaContrato");
            builder.Property(e => e.FechaFin).HasColumnName("fechaFin");
            builder.Property(e => e.IdClienteFk).HasColumnName("idClienteFk");
            builder.Property(e => e.IdEmpleadoFk).HasColumnName("idEmpleadoFk");
            builder.Property(e => e.IdEstadoFk).HasColumnName("idEstadoFk");

            builder.HasOne(d => d.IdClienteFkNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.IdClienteFk)
                .HasConstraintName("contrato_ibfk_1");

            builder.HasOne(d => d.IdEmpleadoFkNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.IdEmpleadoFk)
                .HasConstraintName("contrato_ibfk_2");

            builder.HasOne(d => d.IdEstadoFkNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.IdEstadoFk)
                .HasConstraintName("contrato_ibfk_3");
        }
    }
}