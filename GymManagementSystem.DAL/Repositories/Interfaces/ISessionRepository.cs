using GymManagementSystem.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.DAL.Repositories.Interfaces {
    public interface ISessionRepository : IGenericRepository<Session> {
        Task<IEnumerable<Session>> GetAllSessionsWithTrainerAndCategoryAsync(bool tracking = false, CancellationToken ct = default);

        Task<int> GetCountOfBookedSlotsAsync(int sessionId, CancellationToken ct = default);
    }
}
