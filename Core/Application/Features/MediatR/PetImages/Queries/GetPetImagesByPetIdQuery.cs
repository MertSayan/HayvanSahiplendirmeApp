using Application.Features.MediatR.PetImages.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.PetImages.Queries
{
    public class GetPetImagesByPetIdQuery:IRequest<List<GetPetImagesByPetIdQueryResult>>
    {
        public int Id { get; set; }

        public GetPetImagesByPetIdQuery(int id)
        {
            Id = id;
        }
    }
}
