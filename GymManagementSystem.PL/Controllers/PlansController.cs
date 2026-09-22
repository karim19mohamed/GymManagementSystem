using GymManagementSystem.DAL.Data.Models;
using GymManagementSystem.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GymManagementSystem.PL.Controllers {
    public class PlansController(IGenericRepository<Plan> _genericRepository) : Controller {
        public async Task<IActionResult> Index() {
            var plans = await _genericRepository.GetAllPlansAsync();
            return View(plans);
        }

        public async Task<IActionResult> Details(int id) {
            var plan = await _genericRepository.GetByIdAsync(id);
            if (plan == null) {
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }
    }
}
