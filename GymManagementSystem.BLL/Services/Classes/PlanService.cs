using GymManagementSystem.BLL.Services.Interfaces;
using GymManagementSystem.BLL.ViewModels.PlanViewModels;
using GymManagementSystem.DAL.Data.Models;
using GymManagementSystem.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.BLL.Services.Classes {
    public class PlanService(IGenericRepository<Plan> _genericRepository) : IPlanService {
        public async Task<IEnumerable<PlanViewModel>> GetAllPlansAsync(CancellationToken ct = default) {
            var plans = await _genericRepository.GetAllAsync(ct: ct);
            return plans.Select(p => new PlanViewModel {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                DurationDays = p.DurationDays,
                Price = p.Price,
                IsActive = p.IsActive
            });
        }

        public async Task<PlanViewModel?> GetByIdAsync(int id, CancellationToken ct = default) {
            var plan = await _genericRepository.GetByIdAsync(id, ct: ct);
            if (plan == null) {
                return null;
            }
            return new PlanViewModel {
                Id = plan.Id,
                Name = plan.Name,
                Description = plan.Description,
                DurationDays = plan.DurationDays,
                Price = plan.Price,
                IsActive = plan.IsActive
            };
        }
    }
}
