using GymManagementSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Repositories.Interfaces {
    public interface IUnitOfWork {
        Task<int> SaveChangesAsync(CancellationToken ct = default);

        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEnitity, new();
    }
}
