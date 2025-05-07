using Application.Features.MediatR.PetLikes.Results;
using MediatR;

namespace Application.Features.MediatR.PetLikes.Queries
{
    public class GetAllPetLikeByPetIdQuery:IRequest<List<GetAllPetLikeByPetIdQueryResult>>
    {
        public int Id { get; set; }

        public GetAllPetLikeByPetIdQuery(int id)
        {
            Id = id;
        }
    }
}
