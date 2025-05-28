using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
