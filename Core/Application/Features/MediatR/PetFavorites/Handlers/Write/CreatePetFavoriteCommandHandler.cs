using Application.Features.MediatR.PetFavorites.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.PetFavorites.Handlers.Write
{
    public class CreatePetFavoriteCommandHandler : IRequestHandler<CreatePetFavoriteCommand, Unit>
    {
        private readonly IRepository<PetFavorite> _repository;
        private readonly IMapper _mapper;
        public CreatePetFavoriteCommandHandler(IRepository<PetFavorite> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreatePetFavoriteCommand request, CancellationToken cancellationToken)
        {
            var petFavorite=_mapper.Map<PetFavorite>(request);
            await _repository.CreateAsync(petFavorite);
            return Unit.Value;
        }
    }
}
