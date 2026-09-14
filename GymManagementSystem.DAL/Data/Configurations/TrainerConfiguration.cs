using GymManagementSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Data.Configurations {
    public class TrainerConfiguration : GymUserConfiguration<Trainer>, IEntityTypeConfiguration<Trainer> {
        public new void Configure(EntityTypeBuilder<Trainer> builder) {
            base.Configure(builder);

            builder.Property(t => t.CreatedAt)
                   .HasColumnName("HireDate")
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}
