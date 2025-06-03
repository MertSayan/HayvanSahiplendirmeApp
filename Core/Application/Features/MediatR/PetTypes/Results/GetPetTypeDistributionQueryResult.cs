namespace Application.Features.MediatR.PetTypes.Results
{
    public class GetPetTypeDistributionQueryResult
    {
        public string PetTypeName { get; set; }
        public int Count { get; set; }
    }
}
