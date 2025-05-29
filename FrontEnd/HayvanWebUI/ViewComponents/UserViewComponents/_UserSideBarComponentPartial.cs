using HayvanDto.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HayvanWebUI.ViewComponents.UserViewComponents
{
    public class _UserSideBarComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UserSideBarComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7160/api/Auths/GetByIdUser?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetUserDetailDto>(jsonData);
                return View(result);
            }
            return View(new GetUserDetailDto());
        }
    }
}
