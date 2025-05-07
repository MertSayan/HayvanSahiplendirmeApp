using Domain;
using MediatR;

namespace Application.Features.MediatR.PetLikes.Commands
{
    public class CreatePetLikeCommand:IRequest<Unit>
    {
        public int PetId { get; set; }
        public int UserId { get; set; }

    }
}
