namespace Application.Features.MediatR.PetLikes.Results
{
    public class GetAllPetLikeByUserIdQueryResult
    {
        public int PetLikeId { get; set; }
        public int PetId { get; set; }
        public string PetName { get; set; }
    }
}
