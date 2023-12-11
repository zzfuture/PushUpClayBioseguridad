using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("user");

            builder.HasIndex(e => e.Email, "email").IsUnique();

            builder.HasIndex(e => e.Id, "id").IsUnique();

            builder.HasIndex(e => e.Password, "password").IsUnique();

            builder.HasIndex(e => e.Username, "username").IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            builder.Property(e => e.Password)
                .HasMaxLength(150)
                .HasColumnName("password");
            builder.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            builder.HasMany(d => d.IdRolFks).WithMany(p => p.IdUsuarioFks)
                .UsingEntity<Dictionary<string, object>>(
                    "Userrol",
                    r => r.HasOne<Rol>().WithMany()
                        .HasForeignKey("IdRolFk")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("userrol_ibfk_2"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("IdUsuarioFk")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("userrol_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdUsuarioFk", "IdRolFk")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("userrol");
                        j.HasIndex(new[] { "IdRolFk" }, "idRolFk");
                        j.IndexerProperty<int>("IdUsuarioFk").HasColumnName("idUsuarioFk");
                        j.IndexerProperty<int>("IdRolFk").HasColumnName("idRolFk");
                    });
        }
    }
}