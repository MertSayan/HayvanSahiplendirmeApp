using Microsoft.AspNetCore.Mvc;

namespace HayvanWebUI.ViewComponents.RegisterViewComponents
{
    public class _LocationComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
