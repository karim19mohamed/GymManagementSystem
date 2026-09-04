using GymManagementSystem.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GymManagementSystem.PL.Controllers {
    public class PlansController(IPlanRepository planRepository) : Controller {
        public async Task<IActionResult> Index() {
            var plans = await planRepository.GetAllPlansAsync();
            return View(plans);
        }

        public async Task<IActionResult> Details(int id) {
            var plan = await planRepository.GetByIdAsync(id);
            if (plan == null) {
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }
    }
}
