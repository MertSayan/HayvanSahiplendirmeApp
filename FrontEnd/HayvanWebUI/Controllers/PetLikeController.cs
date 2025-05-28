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
