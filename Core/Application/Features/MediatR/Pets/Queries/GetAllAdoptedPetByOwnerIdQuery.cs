using Application.Features.MediatR.Pets.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Pets.Queries
{
    public class GetAllAdoptedPetByOwnerIdQuery:IRequest<List<GetAllAdoptedPetByOwnerIdQueryResult>>
    {
        public int Id { get; set; }

        public GetAllAdoptedPetByOwnerIdQuery(int id)
        {
            Id = id;
        }
    }
}
