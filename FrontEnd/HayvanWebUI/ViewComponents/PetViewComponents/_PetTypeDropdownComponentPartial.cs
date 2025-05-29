using HayvanDto.PetDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HayvanWebUI.ViewComponents.PetViewComponents
{
    public class _PetTypeDropdownComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _PetTypeDropdownComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7160/api/PetTypes");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var petTypes = JsonConvert.DeserializeObject<List<GetAllPetTypeDto>>(json); // dto senin
                return View(petTypes);
            }

            return View(new List<GetAllPetTypeDto>());
        }
    }
}
