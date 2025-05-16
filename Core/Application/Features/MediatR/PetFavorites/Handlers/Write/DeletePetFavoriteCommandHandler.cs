using Application.Features.MediatR.PetFavorites.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.MediatR.PetFavorites.Handlers.Write
{
    public class DeletePetFavoriteCommandHandler : IRequestHandler<DeletePetFavoriteCommand, Unit>
    {
        private readonly IRepository<PetFavorite> _repository;

        public DeletePetFavoriteCommandHandler(IRepository<PetFavorite> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletePetFavoriteCommand request, CancellationToken cancellationToken)
        {
            var petFavorite = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(petFavorite);
            return Unit.Value;
        }
    }
}
