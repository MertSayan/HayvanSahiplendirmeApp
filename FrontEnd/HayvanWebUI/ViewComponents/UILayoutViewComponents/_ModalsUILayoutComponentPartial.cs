using Microsoft.AspNetCore.Mvc;

namespace HayvanWebUI.ViewComponents.UILayoutViewComponents
{
    public class _ModalsUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
