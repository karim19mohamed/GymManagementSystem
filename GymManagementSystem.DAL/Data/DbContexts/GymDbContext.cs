using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GymManagementSystem.DAL.Data.Configurations;
using GymManagementSystem.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.DAL.Data.DbContexts {
    public class GymDbContext : DbContext {
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<HealthRecord> HealthRecords { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server=.;Database=GymManagementSystemDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
