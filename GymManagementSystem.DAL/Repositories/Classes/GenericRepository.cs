using GymManagementSystem.DAL.Data.DbContexts;
using GymManagementSystem.DAL.Data.Models;
using GymManagementSystem.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Repositories.Classes {
    public class GenericRepository<TEntity>(GymDbContext _context) : IGenericRepository<TEntity> where TEntity : BaseEnitity, new() {
        private readonly DbSet<TEntity> _set = _context.Set<TEntity>();
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = false, CancellationToken ct = default) {
            IQueryable<TEntity> query = (tracking) ? _set : _set.AsNoTracking();
            return await query.ToListAsync(ct);
        }
        public async Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default) {
            return await _set.FindAsync(id, ct);
        }
        public void Add(TEntity entity, CancellationToken ct = default) => _set.Add(entity);
        public void Delete(TEntity entity, CancellationToken ct = default) => _set.Remove(entity);
        public void Update(TEntity entity, CancellationToken ct = default) => _set.Update(entity);

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = false, CancellationToken ct = default) {
            return (tracking) ? _set.AnyAsync(predicate, ct) : _set.AsNoTracking().AnyAsync(predicate, ct);
        }

        public Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = false, CancellationToken ct = default) {
            return (tracking) ? _set.FirstOrDefaultAsync(predicate, ct) : _set.AsNoTracking().FirstOrDefaultAsync(predicate, ct);
        }
    }
}
