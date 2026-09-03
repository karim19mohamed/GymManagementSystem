using GymManagementSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Configurations {
    public class PlanConfiguration : IEntityTypeConfiguration<Plan> {
        public void Configure(EntityTypeBuilder<Plan> builder) {
            builder.Property(P => P.Name)
                   .HasColumnType("varchar")
                   .HasMaxLength(50);
            
            builder.Property(P => P.Description)
                   .HasColumnType("varchar")
                   .HasMaxLength(200);
            
            builder.Property(P => P.Price)
                   .HasPrecision(10, 2);
            
            builder.Property(P => P.IsActive)
                   .HasDefaultValue(true);
            
            builder.Property(P => P.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            builder.ToTable(Tb => {
                Tb.HasCheckConstraint("PlanDurationCheck", "DurationDays Between 0 And 365");
            });
        }
    }
}
