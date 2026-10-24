using GymManagementSystem.DAL.Data.DbContexts;
using GymManagementSystem.DAL.Data.Models;
using GymManagementSystem.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Repositories.Classes {
    public class UnitOfWork(GymDbContext _context) : IUnitOfWork {
        private readonly Dictionary<string, object> _repositories = [];
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEnitity, new() {
            var name = typeof(TEntity).Name;
            if (_repositories.TryGetValue(name, out object? repo))
                return (IGenericRepository < TEntity >) repo;
            var newRepo = new GenericRepository<TEntity>(_context);
            _repositories[name] = newRepo;
            return newRepo;
        }

        public async Task<int> SaveChangesAsync(CancellationToken ct = default) {
            return await _context.SaveChangesAsync(ct);
        }
    }
}
