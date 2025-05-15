using Application.Features.MediatR.Pets.Results;
using MediatR;

namespace Application.Features.MediatR.Pets.Queries
{
    public class GetAllActivePetByOwnerIdQuery:IRequest<List<GetAllActivePetByOwnerIdQueryResult>>
    {
        public int Id { get; set; }

        public GetAllActivePetByOwnerIdQuery(int id)
        {
            Id = id;
        }
    }
}
