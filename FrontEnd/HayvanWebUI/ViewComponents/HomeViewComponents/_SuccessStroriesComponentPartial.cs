using Microsoft.AspNetCore.Mvc;

namespace HayvanWebUI.ViewComponents.HomeViewComponents
{
    public class _SuccessStroriesComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
