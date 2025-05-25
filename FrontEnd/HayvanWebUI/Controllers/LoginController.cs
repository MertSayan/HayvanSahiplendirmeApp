using HayvanDto.UserDtos;
using HayvanWebUI.Models;
using Humanizer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace HayvanWebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public LoginController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        //burası token ile bağlanacak
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Index(LoginDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7160/api/Auths/Login", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseContent = await responseMessage.Content.ReadAsStringAsync();

                // Sadece token döndüğü için string olarak alıyoruz
                var tokenResponse = JsonConvert.DeserializeObject<TokenResponseDto>(responseContent);
                var tokenString = tokenResponse.Token;

                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(tokenString);

                // JWT içindeki exp claim'ini al
                // JWT içindeki exp claim'ini al
                var expClaim = token.Claims.FirstOrDefault(c => c.Type == "exp");
                DateTime expires;

                if (expClaim != null && long.TryParse(expClaim.Value, out long unixExp))
                {
                    expires = DateTimeOffset.FromUnixTimeSeconds(unixExp).UtcDateTime;
                }
                else
                {
                    expires = DateTime.UtcNow.AddMinutes(30); // fallback
                }

                var claims = token.Claims.ToList();
                claims.Add(new Claim("accessToken", tokenString));

                var identity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                var authProps = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = expires 
                };

                await HttpContext.SignInAsync(
                    JwtBearerDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity),
                    authProps);


                return RedirectToAction("Index","Home");
            }
            return View();
        }

    }
}
