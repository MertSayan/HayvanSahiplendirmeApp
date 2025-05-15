using Application.Features.MediatR.AdoptionRequests.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.AdoptionRequests.Queries
{
    public class GetAllIncomingAdoptionByOwnerIdQuery : IRequest<List<GetAllIncomingAdoptionByOwnerIdQueryResult>>
    {
        public int Id { get; set; }

        public GetAllIncomingAdoptionByOwnerIdQuery(int id)
        {
            Id = id;
        }
    }
}
