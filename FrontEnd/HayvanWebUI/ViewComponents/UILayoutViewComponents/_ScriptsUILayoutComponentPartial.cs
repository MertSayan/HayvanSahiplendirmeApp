using Microsoft.AspNetCore.Mvc;

namespace HayvanWebUI.ViewComponents.UILayoutViewComponents
{
    public class _ScriptsUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
