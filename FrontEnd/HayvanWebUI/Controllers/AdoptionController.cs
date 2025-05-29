using HayvanDto.AdoptionRequestDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HayvanWebUI.Controllers
{
    public class AdoptionController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdoptionController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdoptionRequest([FromBody] CreateAdoptionRequestDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7160/api/AdoptionRequests", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }
    }
}
