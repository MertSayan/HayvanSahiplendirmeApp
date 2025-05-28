using Application.Features.MediatR.Pets.Results;
using MediatR;

namespace Application.Features.MediatR.Pets.Queries
{
    public class GetByIdPetQuery:IRequest<GetByIdPetQueryResult>
    {
        public GetByIdPetQuery(int petId, int currentUserId)
        {
            PetId = petId;
            CurrentUserId = currentUserId;
        }

        public int PetId { get; set; }
        public int CurrentUserId { get; set; }

        
    }
}
