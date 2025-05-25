using Microsoft.AspNetCore.Mvc;

namespace HayvanWebUI.Controllers
{
    public class LoginController : Controller
    {
        //burası token ile bağlanacak
        public IActionResult Index()
        {
            return View();
        }
    }
}
