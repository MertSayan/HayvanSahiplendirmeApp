using MediatR;

namespace Application.Features.MediatR.PetFavorites.Commands
{
    public class DeletePetFavoriteCommand:IRequest<Unit>
    {
        public DeletePetFavoriteCommand(int userId, int petId)
        {
            PetId = petId;
            UserId = userId;
        }

        public int PetId { get; set; }
        public int UserId { get; set; }

    }
}
