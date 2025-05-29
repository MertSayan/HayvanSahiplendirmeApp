using Microsoft.AspNetCore.Mvc;

namespace HayvanWebUI.ViewComponents.HomeViewComponents
{
    public class _InfoComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
