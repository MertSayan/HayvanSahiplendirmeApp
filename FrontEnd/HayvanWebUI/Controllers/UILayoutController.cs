using Microsoft.AspNetCore.Mvc;

namespace HayvanWebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
