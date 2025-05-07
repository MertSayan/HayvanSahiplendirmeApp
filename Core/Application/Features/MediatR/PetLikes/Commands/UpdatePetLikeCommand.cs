using MediatR;

namespace Application.Features.MediatR.PetLikes.Commands
{
    public class UpdatePetLikeCommand:IRequest<Unit>
    {
        public int PetLikeId { get; set; }
        public int PetId { get; set; }
        public int UserId { get; set; }
    }
}
