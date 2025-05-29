using HayvanDto.AdoptionRequestDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HayvanWebUI.ViewComponents.UserViewComponents
{
    public class _ProfileRequestListComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProfileRequestListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7160/api/AdoptionRequests/GetAllIncomingAdoptionByOwnerId?ownerId="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var result=JsonConvert.DeserializeObject<List<GetAllAdoptionRequestByOwnerIdDto>>(jsonData);
                return View(result);
            }
            return View(new GetAllAdoptionRequestByOwnerIdDto());
        }
    }
}
