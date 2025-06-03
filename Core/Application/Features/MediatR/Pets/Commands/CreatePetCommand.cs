using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Pets.Commands
{
    public class CreatePetCommand:IRequest<Unit>
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
