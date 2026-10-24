using GymManagementSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Repositories.Interfaces {
    public interface IGenericRepository<TEntity> where TEntity : BaseEnitity, new() {
        Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = false, CancellationToken ct = default);

        Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default);

        void Add(TEntity entity, CancellationToken ct = default);

        void Update(TEntity entity, CancellationToken ct = default);

        void Delete(TEntity entity, CancellationToken ct = default);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = false, CancellationToken ct = default);

        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = false, CancellationToken ct = default);
    }
}
