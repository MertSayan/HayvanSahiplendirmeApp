using Application.Features.MediatR.Pets.Queries;
using Application.Features.MediatR.Pets.Results;
using Application.Interfaces.PetInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Pets.Handlers.Read
{
    public class GetPetByIdQueryHandler : IRequestHandler<GetPetByIdQuery, GetPetByIdQueryResult>
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;
        public GetPetByIdQueryHandler(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<GetPetByIdQueryResult> Handle(GetPetByIdQuery request, CancellationToken cancellationToken)
        {
            var pet = await _petRepository.GetByIdPetAsync(request.Id);

            return _mapper.Map<GetPetByIdQueryResult>(pet);

        }
    }
}
