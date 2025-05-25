using Application.Features.MediatR.Pets.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Pets.Queries
{
    public class GetFeaturedPetQuery:IRequest<List<GetFeaturedPetQueryResult>>
    {
        public int Count { get; set; }

        public GetFeaturedPetQuery(int count)
        {
            Count = count;
        }
    }
}
