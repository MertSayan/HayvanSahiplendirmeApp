using Microsoft.AspNetCore.Http;

namespace Application.Features.MediatR.Pets.Results
{
    public class GetPetByIdQueryResult
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public int PetTypeId { get; set; }
        public string PetTypeName { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public bool IsVaccinated { get; set; }
        public bool IsNeutered { get; set; }
        public string? Breed { get; set; }
        public string ExistingImagePath { get; set; }
    }
}
