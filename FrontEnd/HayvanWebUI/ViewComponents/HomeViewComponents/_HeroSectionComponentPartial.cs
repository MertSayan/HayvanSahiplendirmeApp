using Microsoft.AspNetCore.Mvc;

namespace HayvanWebUI.ViewComponents.HomeViewComponents
{
    public class _HeroSectionComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
