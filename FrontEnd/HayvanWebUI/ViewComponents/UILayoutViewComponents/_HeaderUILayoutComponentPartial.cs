using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HayvanWebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeaderUILayoutComponentPartial:ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = HttpContext.User;

            if (user.Identity != null && user.Identity.IsAuthenticated)
            {
                var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userName = user.FindFirst(ClaimTypes.Name)?.Value;

                ViewBag.UserId = userId;
                ViewBag.UserName = userName;
            }

            return View();
        }
    }
}
