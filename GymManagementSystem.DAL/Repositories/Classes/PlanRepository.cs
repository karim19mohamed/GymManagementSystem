using GymManagementSystem.DAL.DbContexts;
using GymManagementSystem.DAL.Models;
using GymManagementSystem.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Repositories.Classes {
    public class PlanRepository(GymDbContext context) : IPlanRepository {
        public async Task<IEnumerable<Plan>> GetAllPlansAsync(bool tracking = false, CancellationToken ct = default) {
            IQueryable<Plan> query = (tracking) ? context.Plans : context.Plans.AsNoTracking();
            return await query.ToListAsync(ct);
        }
        public async Task<Plan?> GetByIdAsync(int id, CancellationToken ct = default) {
            return await context.Plans.FindAsync(id, ct);
        }
        public async Task<int> AddAsync(Plan plan, CancellationToken ct = default) {
            context.Plans.Add(plan);
            return await context.SaveChangesAsync(ct);
        }

        public async Task<int> DeleteAsync(Plan plan, CancellationToken ct = default) {
            context.Plans.Remove(plan);
            return await context.SaveChangesAsync(ct);
        }
        public async Task<int> UpdateAsync(Plan plan, CancellationToken ct = default) {
            context.Plans.Update(plan);
            return await context.SaveChangesAsync(ct);
        }
    }
}
