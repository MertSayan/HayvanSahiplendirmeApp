using Application.Features.MediatR.Pets.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Pets.Queries
{
    public class GetLastsPetQuery:IRequest<List<GetLastsPetQueryResult>>
    {
        public int Count { get; set; }

        public GetLastsPetQuery(int count)
        {
            Count = count;
        }
    }
}
