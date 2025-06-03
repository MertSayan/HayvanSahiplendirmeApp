using Microsoft.AspNetCore.Http;

namespace HayvanDto.UserDtos
{
    public class UpdateUserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IFormFile? ProfilePictureUrl { get; set; }
        public string? ExistingImagePath { get; set; } // Eski resim yolu
        public string City { get; set; }
        public string District { get; set; }
        public string? AboutMe { get; set; } // Profil açıklaması

    }
}
