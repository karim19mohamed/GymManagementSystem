using GymManagementSystem.BLL.Services.Classes;
using GymManagementSystem.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.PL.Controllers {
    public class MembersController(IMemberService _memberService) : Controller {
        public async Task<IActionResult> Index() {
            var plans = await _memberService.GetAllMembersAsync();
            return View(plans);
        }
    }
}
