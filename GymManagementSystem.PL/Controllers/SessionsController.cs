using GymManagementSystem.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GymManagementSystem.PL.Controllers {
    public class SessionsController(ISessionService _sessionService) : Controller {
        public async Task<IActionResult> Index(CancellationToken ct) {
            var sessions = await _sessionService.GetAllSessionsAsync(ct:ct);
            return View(sessions);
        }
    }
}
