using HayvanDto.PetDtos;
using HayvanWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace HayvanWebUI.Controllers
{
    public class PetController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PetController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
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
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userId = int.TryParse(userIdString, out var parsedId) ? parsedId : 0;
            ViewBag.UserId = userId;
            var client =_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7160/api/Pets/ById?petId={id}&currentUserId={userId}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GetPetDetailDto>(jsonData);
                return View(result);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(AddPetCommentDto dto)
        {

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var userName = User.Identity?.Name ?? "Kullanıcı";
            var userImageUrl = "/images/default-avatar.png"; // Dilersen veritabanından getir

            dto.UserId = userId;

            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7160/api/PetComments", content);

            if (response.IsSuccessStatusCode)
            {
                return Json(new
                {
                    success = true,
                    userId = userId,
                    userName = userName,
                    userImageUrl = userImageUrl,
                    commentText = dto.CommentText,
                    createdDate = DateTime.Now.ToString("dd MMM yyyy HH:mm")
                });
            }

            return Json(new { success = false });
        }

    }
}
