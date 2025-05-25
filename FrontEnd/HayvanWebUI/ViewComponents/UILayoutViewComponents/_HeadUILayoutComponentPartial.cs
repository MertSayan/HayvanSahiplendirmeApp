using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HayvanWebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeadUILayoutComponentPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userName = HttpContext.User.Identity?.Name;
            var userSurname = HttpContext.User.FindFirst(ClaimTypes.Surname)?.Value;

            ViewBag.UserName = userName;
            ViewBag.UserSurname = userSurname;

            return View();
        }
        //Dikkat: User yerine HttpContext.User kullanman gerekiyor çünkü bu bir ViewComponent.

    }
}
