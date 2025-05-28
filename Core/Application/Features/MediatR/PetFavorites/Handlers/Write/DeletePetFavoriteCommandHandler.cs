using Application.Features.MediatR.PetFavorites.Commands;
using Application.Interfaces.PetFavoritesInterface;
using MediatR;

namespace Application.Features.MediatR.PetFavorites.Handlers.Write
{
    public class DeletePetFavoriteCommandHandler : IRequestHandler<DeletePetFavoriteCommand, Unit>
    {
        private readonly IPetFavoritesRepository _petFavoriteRepository;

        public DeletePetFavoriteCommandHandler(IPetFavoritesRepository petFavoriteRepository)
        {
            _petFavoriteRepository = petFavoriteRepository;
        }

        public async Task<Unit> Handle(DeletePetFavoriteCommand request, CancellationToken cancellationToken)
        {
            var petFavorite = await _petFavoriteRepository.GetPetFavoriteByIdAsync(request.UserId,request.PetId);
            await _petFavoriteRepository.DeletePetFavoriteAsync(petFavorite);
            return Unit.Value;
        }
    }
}
