namespace Application.Features.MediatR.Pets.Results
{
    public class GetAllAdoptedPetByOwnerIdQueryResult
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public string PetTypeName { get; set; }
        public string Age { get; set; }
        public string Description { get; set; }
        public string MainImageUrl { get; set; }
    }
}
