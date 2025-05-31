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

        [HttpPost]
        public async Task<IActionResult> AcceptAdoptionRequest(int adoptionRequestId)
        {
            var client = _httpClientFactory.CreateClient();

            var dto = new { Id = adoptionRequestId };
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7160/api/AdoptionRequests/Accept", content);

            return RedirectToAction("Index", "User"); // veya View() vs
        }

        [HttpPost]
        public async Task<IActionResult> RejectAdoptionRequest(int adoptionRequestId)
        {
            var client = _httpClientFactory.CreateClient();

            var dto = new { Id = adoptionRequestId };
            var content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7160/api/AdoptionRequests/Reject", content);

            return RedirectToAction("Index", "User");
        }

    }
}
