using GymManagementSystem.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GymManagementSystem.PL.Controllers {
    public class PlansController(IPlanService _planService) : Controller {
        public async Task<IActionResult> Index() {
            var plans = await _planService.GetAllPlansAsync();
            return View(plans);
        }

        public async Task<IActionResult> Details(int id) {
            var plan = await _planService.GetByIdAsync(id);
            if (plan == null) {
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }
    }
}
