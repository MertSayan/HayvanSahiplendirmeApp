using Application.Features.MediatR.PetLikes.Results;
using MediatR;

namespace Application.Features.MediatR.PetLikes.Queries
{
    public class GetLikeCountByPetIdQuery:IRequest<GetLikeCountByPetIdQueryResult>
    {
        public int PetId { get; set; }

        public GetLikeCountByPetIdQuery(int petId)
        {
            PetId = petId;
        }
    }
}
