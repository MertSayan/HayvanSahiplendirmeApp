using Application.Features.MediatR.AdoptionRequests.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.AdoptionRequests.Queries
{
    public class GetAllAdoptionRequestByUserIdQuery:IRequest<List<GetAllAdoptionRequestByUserIdQueryResult>>
    {
        public int Id { get; set; }

        public GetAllAdoptionRequestByUserIdQuery(int id)
        {
            Id = id;
        }
    }
}
