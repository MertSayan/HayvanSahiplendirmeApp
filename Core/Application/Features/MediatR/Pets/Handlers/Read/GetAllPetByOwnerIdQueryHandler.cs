using Application.Features.MediatR.Pets.Queries;
using Application.Features.MediatR.Pets.Results;
using Application.Interfaces.PetInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Pets.Handlers.Read
{
    public class GetAllPetByOwnerIdQueryHandler : IRequestHandler<GetAllPetByOwnerIdQuery, List<GetAllPetByOwnerIdQueryResult>>
    {
        private readonly IPetRepository _repository;
        private readonly IMapper _mapper;
        public GetAllPetByOwnerIdQueryHandler(IPetRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAllPetByOwnerIdQueryResult>> Handle(GetAllPetByOwnerIdQuery request, CancellationToken cancellationToken)
        {
            var pets = await _repository.GetAllPetByOwnerIdAsync(request.Id);
            return _mapper.Map<List<GetAllPetByOwnerIdQueryResult>>(pets);
        }
    }
}
