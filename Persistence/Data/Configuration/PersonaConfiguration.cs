using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("persona");

            builder.HasIndex(e => e.Id, "id").IsUnique();

            builder.HasIndex(e => e.IdCiudadFk, "idCiudadFk");

            builder.HasIndex(e => e.IdDireccionFk, "idDireccionFk");

            builder.HasIndex(e => e.IdPersona, "idPersona").IsUnique();

            builder.HasIndex(e => e.IdTipoPersonaFk, "idTipoPersonaFk");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.DateReg).HasColumnName("dateReg");
            builder.Property(e => e.IdCiudadFk).HasColumnName("idCiudadFk");
            builder.Property(e => e.IdDireccionFk).HasColumnName("idDireccionFk");
            builder.Property(e => e.IdPersona).HasColumnName("idPersona");
            builder.Property(e => e.IdTipoPersonaFk).HasColumnName("idTipoPersonaFk");

            builder.HasOne(d => d.IdCiudadFkNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdCiudadFk)
                .HasConstraintName("persona_ibfk_2");

            builder.HasOne(d => d.IdDireccionFkNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdDireccionFk)
                .HasConstraintName("persona_ibfk_3");

            builder.HasOne(d => d.IdTipoPersonaFkNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdTipoPersonaFk)
                .HasConstraintName("persona_ibfk_1");
        }
    }
}