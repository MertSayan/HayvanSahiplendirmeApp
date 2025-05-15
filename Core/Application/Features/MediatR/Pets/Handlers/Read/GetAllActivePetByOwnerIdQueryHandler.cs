using Application.Features.MediatR.Pets.Queries;
using Application.Features.MediatR.Pets.Results;
using Application.Interfaces.PetInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Pets.Handlers.Read
{
    public class GetAllActivePetByOwnerIdQueryHandler : IRequestHandler<GetAllActivePetByOwnerIdQuery, List<GetAllActivePetByOwnerIdQueryResult>>
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;
        public GetAllActivePetByOwnerIdQueryHandler(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllActivePetByOwnerIdQueryResult>> Handle(GetAllActivePetByOwnerIdQuery request, CancellationToken cancellationToken)
        {
            var activePets = await _petRepository.GetAllActivePetByOwnerIdAsync(request.Id);
            return _mapper.Map<List<GetAllActivePetByOwnerIdQueryResult>>(activePets);
        }
    }
}
