using Application.Features.MediatR.AdoptionTrackings.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.AdoptionTrackings.Queries
{
    public class GetByIdAdoptionTrackingQuery:IRequest<GetByIdAdoptionTrackingQueryResult>
    {
        public int Id { get; set; }

        public GetByIdAdoptionTrackingQuery(int id)
        {
            Id = id;
        }
    }
}
