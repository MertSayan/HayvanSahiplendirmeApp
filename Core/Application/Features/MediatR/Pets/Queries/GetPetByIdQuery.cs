using Application.Features.MediatR.Pets.Results;
using MediatR;

namespace Application.Features.MediatR.Pets.Queries
{
    public class GetPetByIdQuery:IRequest<GetPetByIdQueryResult>
    {
        public int Id { get; set; }

        public GetPetByIdQuery(int id)
        {
            Id = id;
        }
    }
}
