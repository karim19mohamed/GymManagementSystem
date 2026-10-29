using AutoMapper;
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
    public class PlanService(IUnitOfWork _unitOfWork, IMapper _mapper) : IPlanService {
        public async Task<IEnumerable<PlanViewModel>> GetAllPlansAsync(CancellationToken ct = default) {
            var plans = await _unitOfWork.GetRepository<Plan>().GetAllAsync(ct: ct);
            return _mapper.Map<IEnumerable<PlanViewModel>>(plans);
        }

        public async Task<PlanViewModel?> GetByIdAsync(int id, CancellationToken ct = default) {
            var plan = await _unitOfWork.GetRepository<Plan>().GetByIdAsync(id, ct: ct);
            if (plan == null) {
                return null;
            }
            return _mapper.Map<PlanViewModel>(plan);
        }
    }
}
