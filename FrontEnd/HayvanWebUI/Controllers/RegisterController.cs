using HayvanDto.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace HayvanWebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateUserDto dto, string returnUrl = null)
        {
            var client = _httpClientFactory.CreateClient();

            var formContent = new MultipartFormDataContent();

            formContent.Add(new StringContent(dto.Name), "Name");
            formContent.Add(new StringContent(dto.Surname), "Surname");
            formContent.Add(new StringContent(dto.Email), "Email");
            formContent.Add(new StringContent(dto.Password), "Password");
            formContent.Add(new StringContent(dto.City), "City");
            formContent.Add(new StringContent(dto.District), "District");

            if (!string.IsNullOrEmpty(dto.AboutMe))
                formContent.Add(new StringContent(dto.AboutMe), "AboutMe");

            if (dto.ProfilePictureUrl != null && dto.ProfilePictureUrl.Length > 0)
            {
                var fileContent = new StreamContent(dto.ProfilePictureUrl.OpenReadStream());
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(dto.ProfilePictureUrl.ContentType);
                formContent.Add(fileContent, "ProfilePictureUrl", dto.ProfilePictureUrl.FileName);
            }

            var responseMessage = await client.PostAsync("https://localhost:7160/api/Auths/CreateUser", formContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            return View(dto);
        }
    }
}
