namespace Application.Features.MediatR.PetLikes.Results
{
    public class GetAllPetLikeByPetIdQueryResult
    {
        public int PetLikeId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
