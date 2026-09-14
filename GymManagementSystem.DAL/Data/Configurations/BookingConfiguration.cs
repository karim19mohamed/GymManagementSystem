using GymManagementSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Data.Configurations {
    public class BookingConfiguration : IEntityTypeConfiguration<Booking> {
        public void Configure(EntityTypeBuilder<Booking> builder) {
            builder.Ignore(b => b.Id);
            builder.HasKey(b => new { b.MemberId, b.SessionId });
            builder.Property(b => b.CreatedAt)
                   .HasColumnName("BookingDate")
                   .HasDefaultValueSql("GETDATE()");
        }
    }
}
