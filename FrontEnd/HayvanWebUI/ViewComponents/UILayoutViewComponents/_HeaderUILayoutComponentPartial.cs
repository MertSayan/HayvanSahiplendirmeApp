using Microsoft.AspNetCore.Mvc;

namespace HayvanWebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeaderUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
