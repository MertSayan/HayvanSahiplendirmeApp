using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HayvanWebUI.Controllers
{
    public class PetLikeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PetLikeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> GetLikeCount(int petId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7160/api/PetLikes/ByPetId?petId={petId}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return Content(json, "application/json");
            }

            return Json(new { likeCount = 0 });
        }

        [HttpPost]
        public async Task<IActionResult> Like(int userId,int petId)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(new {UserId=userId, PetId=petId});
            var content=new StringContent(jsonData,Encoding.UTF8,"application/json");

            var responseMessage = await client.PostAsync("https://localhost:7160/api/PetLikes", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UnLike(int userId, int petId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7160/api/PetLikes?userId={userId}&petId={petId}");
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
