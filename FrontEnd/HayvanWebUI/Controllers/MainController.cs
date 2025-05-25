using Microsoft.AspNetCore.Mvc;

namespace HayvanWebUI.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
