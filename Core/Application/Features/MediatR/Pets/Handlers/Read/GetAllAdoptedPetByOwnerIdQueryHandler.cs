using Application.Features.MediatR.Pets.Queries;
using Application.Features.MediatR.Pets.Results;
using Application.Interfaces.PetInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Pets.Handlers.Read
{
    public class GetAllAdoptedPetByOwnerIdQueryHandler : IRequestHandler<GetAllAdoptedPetByOwnerIdQuery, List<GetAllAdoptedPetByOwnerIdQueryResult>>
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public GetAllAdoptedPetByOwnerIdQueryHandler(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllAdoptedPetByOwnerIdQueryResult>> Handle(GetAllAdoptedPetByOwnerIdQuery request, CancellationToken cancellationToken)
        {
            var adoptedPets = await _petRepository.GetAllAdoptedPetByOwnerIdAsync(request.Id);
            return _mapper.Map<List<GetAllAdoptedPetByOwnerIdQueryResult>>(adoptedPets);
        }
    }
}
