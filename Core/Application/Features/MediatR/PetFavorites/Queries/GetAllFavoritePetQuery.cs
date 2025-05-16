using Application.Features.MediatR.PetFavorites.Results;
using MediatR;

namespace Application.Features.MediatR.PetFavorites.Queries
{
    public class GetAllFavoritePetQuery:IRequest<List<GetAllFavoritePetQueryResult>>
    {
        public int Id { get; set; }

        public GetAllFavoritePetQuery(int id)
        {
            Id = id;
        }
    }
}
