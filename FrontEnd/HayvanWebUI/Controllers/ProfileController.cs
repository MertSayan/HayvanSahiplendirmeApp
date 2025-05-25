using Microsoft.AspNetCore.Mvc;

namespace HayvanWebUI.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
