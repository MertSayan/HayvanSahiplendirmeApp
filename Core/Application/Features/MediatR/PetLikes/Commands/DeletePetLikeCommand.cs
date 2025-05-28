using MediatR;

namespace Application.Features.MediatR.PetLikes.Commands
{
    public class DeletePetLikeCommand:IRequest<Unit>
    {
        public DeletePetLikeCommand(int userId, int petId)
        {
            UserId = userId;
            PetId = petId;
        }

        public int UserId { get; set; }
        public int PetId { get; set; }

    }
}
