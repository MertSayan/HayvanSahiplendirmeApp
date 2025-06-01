using Application.Features.MediatR.Pets.Queries;
using Application.Features.MediatR.Pets.Results;
using Application.Interfaces.PetInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Pets.Handlers.Read
{
    public class GetLastsPetQueryHandler : IRequestHandler<GetLastsPetQuery, List<GetLastsPetQueryResult>>
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;
        public GetLastsPetQueryHandler(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<List<GetLastsPetQueryResult>> Handle(GetLastsPetQuery request, CancellationToken cancellationToken)
        {
            var lastpets = await _petRepository.GetLastPetsAsync(request.Count);
            return _mapper.Map<List<GetLastsPetQueryResult>>(lastpets);
        }
    }
}
