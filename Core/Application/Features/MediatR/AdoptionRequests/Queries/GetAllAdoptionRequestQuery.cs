using Application.Features.MediatR.AdoptionRequests.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.AdoptionRequests.Queries
{
    public class GetAllAdoptionRequestQuery:IRequest<List<GetAllAdoptionRequestQueryResult>>
    {
    }
}
