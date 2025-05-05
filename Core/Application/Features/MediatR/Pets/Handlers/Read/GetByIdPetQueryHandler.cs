using Application.Features.MediatR.Pets.Queries;
using Application.Features.MediatR.Pets.Results;
using Application.Interfaces.PetInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Pets.Handlers.Read
{
    public class GetByIdPetQueryHandler : IRequestHandler<GetByIdPetQuery, GetByIdPetQueryResult>
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public GetByIdPetQueryHandler(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdPetQueryResult> Handle(GetByIdPetQuery request, CancellationToken cancellationToken)
        {
            var pet = await _petRepository.GetByIdPetAsync(request.Id);

            return _mapper.Map<GetByIdPetQueryResult>(pet);
        }
    }
}
