using Application.Features.MediatR.PetTypes.Queries;
using Application.Features.MediatR.PetTypes.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.PetTypes.Handlers.Read
{
    public class GetAllPetTypeQueryHandler : IRequestHandler<GetAllPetTypeQuery, List<GetAllPetTypeQueryResult>>
    {
        private readonly IRepository<PetType> _repository;
        private readonly IMapper _mapper;
        public GetAllPetTypeQueryHandler(IRepository<PetType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAllPetTypeQueryResult>> Handle(GetAllPetTypeQuery request, CancellationToken cancellationToken)
        {
            var petTypes = await _repository.GetAllAsync();
            return _mapper.Map<List<GetAllPetTypeQueryResult>>(petTypes);
        }
    }
}
