using MediatR;

namespace Application.Features.MediatR.PetFavorites.Commands
{
    public class CreatePetFavoriteCommand:IRequest<Unit>
    {
        public int PetId { get; set; }
        public int UserId { get; set; }
    }
}
