using HayvanDto.PetDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HayvanWebUI.ViewComponents.HomeViewComponents
{
    public class _FeaturedPetsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FeaturedPetsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7160/api/Pets/Top3LikePet?sayi=3");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetFeaturedPetsDto>>(jsonData);
                return View(values);
            }
            return View();

        }
    }
}
