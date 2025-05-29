using Application.Features.MediatR.PetTypes.Results;
using MediatR;

namespace Application.Features.MediatR.PetTypes.Queries
{
    public class GetAllPetTypeQuery:IRequest<List<GetAllPetTypeQueryResult>>
    {
    }
}
