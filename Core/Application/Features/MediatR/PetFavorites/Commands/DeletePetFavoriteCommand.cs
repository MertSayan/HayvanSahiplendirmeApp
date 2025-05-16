using MediatR;

namespace Application.Features.MediatR.PetFavorites.Commands
{
    public class DeletePetFavoriteCommand:IRequest<Unit>
    {
        public int Id { get; set; }

        public DeletePetFavoriteCommand(int id)
        {
            Id = id;
        }
    }
}
