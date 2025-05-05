using Application.Features.MediatR.Pets.Queries;
using Application.Features.MediatR.Pets.Results;
using Application.Interfaces.PetInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Pets.Handlers.Read
{
    public class GetAllPetQueryHandler : IRequestHandler<GetAllPetQuery, List<GetAllPetQueryResult>>
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public GetAllPetQueryHandler(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllPetQueryResult>> Handle(GetAllPetQuery request, CancellationToken cancellationToken)
        {
            var pets = await _petRepository.GetAllPetAsync();
            return _mapper.Map<List<GetAllPetQueryResult>>(pets);
        }
    }
}
