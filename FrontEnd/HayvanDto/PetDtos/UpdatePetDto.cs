using Microsoft.AspNetCore.Http;

namespace HayvanDto.PetDtos
{
    public class UpdatePetDto
    {
        public int PetId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public bool IsVaccinated { get; set; }
        public bool IsNeutered { get; set; }
        public bool IsAdopted { get; set; }

        public string? ExistingImagePath { get; set; } // Eski resim yolu
        public IFormFile? MainImageUrl { get; set; }   // Yeni yüklenen dosya
    }
}
