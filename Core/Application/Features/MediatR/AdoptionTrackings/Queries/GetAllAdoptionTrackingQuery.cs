using Application.Features.MediatR.AdoptionTrackings.Results;
using MediatR;

namespace Application.Features.MediatR.AdoptionTrackings.Queries
{
    public class GetAllAdoptionTrackingQuery:IRequest<List<GetAllAdoptionTrackingQueryResult>>
    {
       
    }
}
