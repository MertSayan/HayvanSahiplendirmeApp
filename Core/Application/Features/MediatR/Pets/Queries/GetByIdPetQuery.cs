using Application.Features.MediatR.Pets.Results;
using MediatR;

namespace Application.Features.MediatR.Pets.Queries
{
    public class GetByIdPetQuery:IRequest<GetByIdPetQueryResult>
    {
        public int Id { get; set; }

        public GetByIdPetQuery(int id)
        {
            Id = id;
        }
    }
}
