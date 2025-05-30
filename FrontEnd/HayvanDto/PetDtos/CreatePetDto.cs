using Microsoft.AspNetCore.Http;

namespace HayvanDto.PetDtos
{
    public class CreatePetDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int PetTypeId { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public bool IsVaccinated { get; set; }
        public bool IsNeutered { get; set; } //kısırlaştırıldı mı
        public bool IsAdopted { get; set; } // sahiplendirilip sahiplendirilmediği ( ilan aktif mi pasif mi gibi )
        public string? Breed { get; set; } // Örn: "Golden Retriever"
        public IFormFile? MainImageUrl { get; set; }
    }
}
