using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.MediatR.Pets.Commands
{
    public class UpdatePetCommand:IRequest<Unit>
    {
        public int PetId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public bool IsVaccinated { get; set; }
        public bool IsNeutered { get; set; } //kısırlaştırıldı mı
        public bool IsAdopted { get; set; } // sahiplendirilip sahiplendirilmediği ( ilan aktif mi pasif mi gibi )
        public IFormFile? MainImageUrl { get; set; }

    }
}
