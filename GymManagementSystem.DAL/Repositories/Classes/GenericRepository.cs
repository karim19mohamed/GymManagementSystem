using GymManagementSystem.DAL.Data.DbContexts;
using GymManagementSystem.DAL.Data.Models;
using GymManagementSystem.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Repositories.Classes {
    public class GenericRepository<TEntity>(GymDbContext _context) : IGenericRepository<TEntity> where TEntity : BaseEnitity, new() {
        private readonly DbSet<TEntity> _set = _context.Set<TEntity>();
        public async Task<IEnumerable<TEntity>> GetAllPlansAsync(bool tracking = false, CancellationToken ct = default) {
            IQueryable<TEntity> query = (tracking) ? _set : _set.AsNoTracking();
            return await query.ToListAsync(ct);
        }
        public async Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default) {
            return await _set.FindAsync(id, ct);
        }
        public async Task<int> AddAsync(TEntity entity, CancellationToken ct = default) {
            _set.Add(entity);
            return await _context.SaveChangesAsync(ct);
        }

        public async Task<int> DeleteAsync(TEntity entity, CancellationToken ct = default) {
            _set.Remove(entity);
            return await _context.SaveChangesAsync(ct);
        }
        public async Task<int> UpdateAsync(TEntity entity, CancellationToken ct = default) {
            _set.Update(entity);
            return await _context.SaveChangesAsync(ct);
        }
    }
}
