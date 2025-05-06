using Application.Features.MediatR.PetComments.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.PetComments.Queries
{
    public class GetAllPetCommentByPetIdQuery : IRequest<List<GetAllPetCommentByPetIdQueryResult>>
    {
        public int Id { get; set; }

        public GetAllPetCommentByPetIdQuery(int id)
        {
            Id = id;
        }
    }
}
