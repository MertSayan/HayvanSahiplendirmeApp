using HayvanDto.PetImageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HayvanWebUI.ViewComponents.PetViewComponents
{
    public class _PetImagesComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PetImagesComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7160/api/PetImages?id=" + id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetAllPetImageByPetIdDto>>(jsonData);
                return View(result);
            }
            return View();
        }
    }
}
