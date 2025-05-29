using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HayvanWebUI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(userIdStr, out int userId))
            {
                ViewBag.UserId = userId;
            }
            else
            {
                ViewBag.UserId = null; // veya -1
            }
            return View();
        }
    }
}
