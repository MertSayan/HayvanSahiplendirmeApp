using Application.Features.MediatR.PetFavorites.Queries;
using Application.Features.MediatR.PetFavorites.Results;
using Application.Interfaces.PetFavoritesInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.PetFavorites.Handlers.Read
{
    public class GetAllFavoritePetQueryHandler : IRequestHandler<GetAllFavoritePetQuery, List<GetAllFavoritePetQueryResult>>
    {
        private readonly IPetFavoritesRepository _petFavoritesRepository;
        private readonly IMapper _mapper;

        public GetAllFavoritePetQueryHandler(IPetFavoritesRepository petFavoritesRepository, IMapper mapper)
        {
            _petFavoritesRepository = petFavoritesRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllFavoritePetQueryResult>> Handle(GetAllFavoritePetQuery request, CancellationToken cancellationToken)
        {
            var favoritePet = await _petFavoritesRepository.GetMyPetFavoritesAsync(request.Id);
            return _mapper.Map<List<GetAllFavoritePetQueryResult>>(favoritePet);
        }
    }
}
