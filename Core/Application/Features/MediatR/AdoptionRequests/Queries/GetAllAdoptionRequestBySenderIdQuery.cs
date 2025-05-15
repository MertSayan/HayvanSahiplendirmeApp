using Application.Features.MediatR.AdoptionRequests.Results;
using MediatR;

namespace Application.Features.MediatR.AdoptionRequests.Queries
{
    public class GetAllAdoptionRequestBySenderIdQuery:IRequest<List<GetAllAdoptionRequestBySenderIdQueryResult>>
    {
        public int Id { get; set; }

        public GetAllAdoptionRequestBySenderIdQuery(int id)
        {
            Id = id;
        }
    }
}
