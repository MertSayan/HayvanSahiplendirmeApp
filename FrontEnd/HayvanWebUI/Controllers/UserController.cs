using HayvanDto.AdoptionRequestDtos;
using HayvanDto.PetDtos;
using HayvanDto.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace HayvanWebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //Profil Ana Sayfası
        [HttpGet]
        public IActionResult Index()
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(userIdStr, out int userId))
            {
                ViewBag.UserId = userId;
            }
            else
            {
                ViewBag.UserId = null; // veya -1
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var client =_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7160/api/Auths/GetByIdUser?id="+id);
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var result=JsonConvert.DeserializeObject<UpdateUserDto>(jsonData);
                return View(result);
            }
            return View(new UpdateUserDto());
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UpdateUserDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var formData = new MultipartFormDataContent();

            formData.Add(new StringContent(dto.UserId.ToString()), "UserId");
            formData.Add(new StringContent(dto.Name), "Name");
            formData.Add(new StringContent(dto.Surname), "Surname");
            formData.Add(new StringContent(dto.Email), "Email");
            formData.Add(new StringContent(dto.Password), "Password");
            formData.Add(new StringContent(dto.City), "City");
            formData.Add(new StringContent(dto.District), "District");

            if (!string.IsNullOrEmpty(dto.AboutMe))
                formData.Add(new StringContent(dto.AboutMe), "AboutMe");

            if (dto.ProfilePictureUrl != null && dto.ProfilePictureUrl.Length > 0)
            {
                var fileContent = new StreamContent(dto.ProfilePictureUrl.OpenReadStream());
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(dto.ProfilePictureUrl.ContentType);
                formData.Add(fileContent, "ProfilePictureUrl", dto.ProfilePictureUrl.FileName);
            }

            var response = await client.PutAsync("https://localhost:7160/api/Auths/UpdateUser", formData); // 🔁 Güncelleme API endpointini buraya yaz

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index", "User", new { id = dto.UserId });

            // Başarısızsa aynı view'i dto ile tekrar göster
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> MyPets(int id)
        {
            ViewBag.UserId = id;
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7160/api/Pets/GetAllPetByOwnerId?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetAllPetByOwnerIdDto>>(jsonData);
                return View(result);
            }
            return View(new GetAllPetByOwnerIdDto());
        }

        [HttpGet]
        public async Task<IActionResult> SentRequests(int id)
        {
            ViewBag.UserId = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7160/api/AdoptionRequests/GetAllAdoptiobRequestBySenderId?senderId=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetAllAdoptionRequestBySenderIdDto>>(jsonData);
                return View(result);
            }
            return View(new GetAllAdoptionRequestBySenderIdDto());
        }
        [HttpGet]
        public IActionResult ReceivedRequest(int id)
        {
            ViewBag.UserId = id;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MyFavoritte(int id)
        {
            ViewBag.UserId = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7160/api/PetFavorities/GetAllMyFavoritePet?userId=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<GetAllFavoritePetDto>>(jsonData);
                return View(result);
            }
            return View(new GetAllFavoritePetDto());
        }

    }
}
