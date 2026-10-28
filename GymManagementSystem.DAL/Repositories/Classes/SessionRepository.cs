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
    public class SessionRepository(GymDbContext _context) : GenericRepository<Session>(_context), ISessionRepository {
        public async Task<IEnumerable<Session>> GetAllSessionsWithTrainerAndCategoryAsync(bool tracking = false, CancellationToken ct = default) {
            IQueryable<Session> query = (tracking) ? _context.Sessions.Include(s => s.Trainer).Include(s => s.Category) : _context.Sessions.AsNoTracking().Include(s => s.Trainer).Include(s => s.Category);
            return await query.ToListAsync(ct);
        }

        public async Task<int> GetCountOfBookedSlotsAsync(int sessionId, CancellationToken ct = default) {
            return await _context.Bookings.CountAsync(b => b.SessionId == sessionId, ct);
        }
    }
}
