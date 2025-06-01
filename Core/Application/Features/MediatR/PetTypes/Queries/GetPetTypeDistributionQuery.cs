using Application.Features.MediatR.PetTypes.Results;
using MediatR;

namespace Application.Features.MediatR.PetTypes.Queries
{
    public class GetPetTypeDistributionQuery:IRequest<List<GetPetTypeDistributionQueryResult>>
    {
    }
}
