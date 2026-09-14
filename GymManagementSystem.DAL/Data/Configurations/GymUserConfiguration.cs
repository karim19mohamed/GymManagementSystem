using GymManagementSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Data.Configurations {
    public class GymUserConfiguration<T> : IEntityTypeConfiguration<T> where T : GymUser {
        public void Configure(EntityTypeBuilder<T> builder) {
            builder.Property(G => G.Name)
                   .HasColumnType("varchar")
                   .HasMaxLength(50);

            builder.Property(G => G.Email)
                   .HasColumnType("varchar")
                   .HasMaxLength(100);

            builder.HasIndex(G => G.Email)
                   .IsUnique();

            builder.ToTable(Tb => {
                Tb.HasCheckConstraint("CK_GymUser_Email", "Email LIKE '_%@_%._%'");
            });

            builder.Property(G => G.Phone)
                   .HasColumnType("varchar")
                   .HasMaxLength(11);

            builder.HasIndex(G => G.Phone)
                   .IsUnique();

            builder.ToTable(Tb => {
                Tb.HasCheckConstraint("CK_GymUser_Phone", "Phone LIKE '010%' OR " +
                                                          "Phone LIKE '011%' OR " +
                                                          "Phone LIKE '012%' OR " +
                                                          "Phone LIKE '015%'");
            });

            builder.OwnsOne(G => G.Address, address =>
            {
                address.Property(a => a.Street)
                       .HasColumnName("Street")
                       .HasColumnType("varchar")
                       .HasMaxLength(30);
                address.Property(a => a.City)
                       .HasColumnName("City")
                       .HasColumnType("varchar")
                       .HasMaxLength(30);
                address.Property(a => a.BuildingNumber)
                       .HasColumnName("BuildingNumber")
                       .HasColumnType("varchar");
            });
        }
    }
}
