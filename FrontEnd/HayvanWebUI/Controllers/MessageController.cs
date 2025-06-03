using Microsoft.AspNetCore.Mvc;

namespace HayvanWebUI.Controllers
{
    public class MessageController : Controller
    {
        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.ReceiverId = id; // Pet sahibi userId
            return View();
        }
    }
}
