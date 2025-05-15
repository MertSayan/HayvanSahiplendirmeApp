using Application.Features.MediatR.Pets.Results;
using MediatR;

namespace Application.Features.MediatR.Pets.Queries
{
    public class GetAllPetByOwnerIdQuery:IRequest<List<GetAllPetByOwnerIdQueryResult>>
    {
       public int Id { get; set; }

        public GetAllPetByOwnerIdQuery(int id)
        {
            Id = id;
        }
    }
}
