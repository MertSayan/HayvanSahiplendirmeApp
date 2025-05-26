using HayvanDto.PetDtos;
using HayvanWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HayvanWebUI.Controllers
{
    public class PetController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PetController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //[HttpGet]
        //public async Task<IActionResult> Index()
        //{
        //    var client =  _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("https://localhost:7160/api/Pets/Filter");
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData=await responseMessage.Content.ReadAsStringAsync();
        //        var result = JsonConvert.DeserializeObject<List<GetAllFilterPetDto>>(jsonData);
        //        return View(result);
        //    }
        //    return View();
        //}
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int? petTypeId = null, string? age = null, string? city = null)
        {
            var client = _httpClientFactory.CreateClient();

            // Query string oluştur
            var query = $"?Page={page}";
            if (petTypeId.HasValue) query += $"&PetTypeId={petTypeId}";
            if (!string.IsNullOrWhiteSpace(age)) query += $"&Age={age}";
            if (!string.IsNullOrWhiteSpace(city)) query += $"&City={city}";

            var responseMessage = await client.GetAsync("https://localhost:7160/api/Pets/Filter" + query);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var petList = JsonConvert.DeserializeObject<List<GetAllFilterPetDto>>(jsonData);

                var viewModel = new PetListViewModel
                {
                    Pets = petList,
                    CurrentPage = page,
                    TotalPages = 3 // toplam sayfa sayısını API'den çekmiyorsan elle veriyorsun burada (geliştirilebilir)
                };

                return View(viewModel);
            }

            return View(new PetListViewModel()); // boş modelle dön
        }

    }
}
