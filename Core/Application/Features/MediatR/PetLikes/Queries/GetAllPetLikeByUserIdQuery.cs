using Application.Features.MediatR.PetLikes.Results;
using MediatR;

namespace Application.Features.MediatR.PetLikes.Queries
{
    public class GetAllPetLikeByUserIdQuery:IRequest<List<GetAllPetLikeByUserIdQueryResult>>
    {
        public int Id { get; set; }

        public GetAllPetLikeByUserIdQuery(int id)
        {
            Id = id;
        }
    }
}
