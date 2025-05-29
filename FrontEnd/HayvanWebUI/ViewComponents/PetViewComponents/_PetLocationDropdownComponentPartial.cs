using Microsoft.AspNetCore.Mvc;

namespace HayvanWebUI.ViewComponents.PetViewComponents
{
    public class _PetLocationDropdownComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
