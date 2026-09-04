using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagementSystem.DAL.Configurations;
using GymManagementSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagementSystem.DAL.DbContexts {
    public class GymDbContext : DbContext {
        public DbSet<Plan> Plans { get; set; }

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server=.;Database=GymManagementSystemDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new PlanConfiguration());
        }
    }
}
