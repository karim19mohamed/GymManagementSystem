using GymManagementSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Repositories.Interfaces {
    public interface IGenericRepository<TEntity> where TEntity : BaseEnitity, new() {
        Task<IEnumerable<TEntity>> GetAllAsync(bool tracking = false, CancellationToken ct = default);

        Task<TEntity?> GetByIdAsync(int id, CancellationToken ct = default);

        Task<int> AddAsync(TEntity plan, CancellationToken ct = default);

        Task<int> UpdateAsync(TEntity plan, CancellationToken ct = default);

        Task<int> DeleteAsync(TEntity plan, CancellationToken ct = default);
    }
}
