namespace Application.Features.MediatR.Pets.Results
{
    public class GetAllFilterPetQueryResult
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public string PetTypeName { get; set; }
        public string Age { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public bool IsVaccinated { get; set; }
        public bool IsNeutered { get; set; }
        public string MainImageUrl { get; set; }
        public string Description { get; set; }
        public int PetLike {  get; set; }
    }
}
