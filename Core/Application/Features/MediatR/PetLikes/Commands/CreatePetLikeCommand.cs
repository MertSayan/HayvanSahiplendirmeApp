using Domain;
using MediatR;

namespace Application.Features.MediatR.PetLikes.Commands
{
    public class CreatePetLikeCommand:IRequest<Unit>
    {
        public int UserId { get; set; }
        public int PetId { get; set; }

    }
}
