using Microsoft.AspNetCore.Mvc;

namespace HayvanWebUI.ViewComponents.PetViewComponents
{
    public class _CreateSideBarComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CreateSideBarComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
