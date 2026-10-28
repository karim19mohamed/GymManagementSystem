using GymManagementSystem.BLL.Services.Interfaces;
using GymManagementSystem.BLL.ViewModels.SessionViewModels;
using GymManagementSystem.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem.BLL.Services.Classes {
    public class SessionService(IUnitOfWork _unitOfWork) : ISessionService {
        public async Task<IEnumerable<SessionViewModel>?> GetAllSessionsAsync(CancellationToken ct = default) {
            var sessions = await _unitOfWork._sessionRepository.GetAllSessionsWithTrainerAndCategoryAsync(ct: ct);
            if (sessions is null || !sessions.Any())
                return null;
            var sessionViewModels = sessions.Select(s => new SessionViewModel {
                Id = s.Id,
                Description = s.Description,
                Capacity = s.Capacity,
                StartDate = s.StartDate,
                EndDate = s.EndDate,
                TrainerName = s.Trainer.Name,
                CategoryName = s.Category.CategoryName
            });
            foreach (var sessionViewModel in sessionViewModels) {
                var availableSlots = await _unitOfWork._sessionRepository.GetCountOfBookedSlotsAsync(sessionViewModel.Id, ct);
                sessionViewModel.AvailableSlots = sessionViewModel.Capacity - availableSlots;
            }
            return sessionViewModels;
        }
    }
}
