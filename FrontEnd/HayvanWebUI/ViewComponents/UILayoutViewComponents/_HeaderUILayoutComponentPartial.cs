using HayvanDto.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace HayvanWebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeaderUILayoutComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HeaderUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = HttpContext.User;

            if (user.Identity != null && user.Identity.IsAuthenticated)
            {
                var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userName = user.FindFirst(ClaimTypes.Name)?.Value;

                ViewBag.UserId = userId;
                ViewBag.UserName = userName;

                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7160/api/Auths/GetByIdUser?id=" + userId);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<GetUserDetailDto>(jsonData);
                    return View(result);
                }
            }
            return View(new GetUserDetailDto());
        }
    }
}
