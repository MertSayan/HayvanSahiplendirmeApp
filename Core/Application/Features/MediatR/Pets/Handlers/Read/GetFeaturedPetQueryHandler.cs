using Application.Features.MediatR.Pets.Queries;
using Application.Features.MediatR.Pets.Results;
using Application.Interfaces.PetInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Pets.Handlers.Read
{
    public class GetFeaturedPetQueryHandler : IRequestHandler<GetFeaturedPetQuery, List<GetFeaturedPetQueryResult>>
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;
        public GetFeaturedPetQueryHandler(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<List<GetFeaturedPetQueryResult>> Handle(GetFeaturedPetQuery request, CancellationToken cancellationToken)
        {
            var pets=await _petRepository.GetTopLikedPetsAsync(request.Count);
            return _mapper.Map<List<GetFeaturedPetQueryResult>>(pets);
        }
    }
}
