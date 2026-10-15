using GymManagementSystem.BLL.Services.Classes;
using GymManagementSystem.BLL.Services.Interfaces;
using GymManagementSystem.BLL.ViewModels.MemberViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GymManagementSystem.PL.Controllers {
    public class MembersController(IMemberService _memberService) : Controller {
        public async Task<IActionResult> Index() {
            var plans = await _memberService.GetAllMembersAsync();
            return View(plans);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateMemberViewModel member, CancellationToken ct) {
            if (!ModelState.IsValid) return View(member);
            var result = await _memberService.CreateMemberAsync(member, ct:ct);
            if (result)
                TempData["Success"] = "Member Creation is Succeeded";
            else
                TempData["Failure"] = "Member Creation is failed";
            return RedirectToAction(nameof(Index));
        }
    }
}
