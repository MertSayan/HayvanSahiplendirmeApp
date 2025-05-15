using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Pets.Results
{
    public class GetAllPetByOwnerIdQueryResult
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public string PetTypeName { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public bool IsAdopted { get; set; } // sahiplendirilip sahiplendirilmediği ( ilan aktif mi pasif mi gibi )
        public string? Breed { get; set; } // Örn: "Golden Retriever"
        public string MainImageUrl { get; set; }
        public int RequestCount { get; set; }
    }
}
