using Microsoft.AspNetCore.Mvc;

namespace HayvanWebUI.Controllers
{
    public class PetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
