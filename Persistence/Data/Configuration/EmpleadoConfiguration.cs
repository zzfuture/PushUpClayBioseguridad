using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
             builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("empleado");

            builder.HasIndex(e => e.Id, "id").IsUnique();

            builder.HasIndex(e => e.IdPuestoFk, "idPuestoFk");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Apellido)
                .HasMaxLength(50)
                .HasColumnName("apellido");
            builder.Property(e => e.IdPuestoFk).HasColumnName("idPuestoFk");
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            builder.Property(e => e.Telefono)
                .HasMaxLength(10)
                .HasColumnName("telefono");

            builder.HasOne(d => d.IdPuestoFkNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdPuestoFk)
                .HasConstraintName("empleado_ibfk_1");
        }
    }
}