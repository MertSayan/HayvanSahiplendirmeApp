using HayvanDto.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HayvanWebUI.ViewComponents.UserViewComponents
{
    public class _ProfileStatsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProfileStatsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7160/api/Auths/GetByIdUserProfileStats?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetUserStatsDto>(jsonData);
                return View(result);
            }
            return View(new GetUserDetailDto());
        }
    }
}
