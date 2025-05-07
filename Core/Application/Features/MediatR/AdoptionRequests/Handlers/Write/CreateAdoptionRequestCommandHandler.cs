using Application.Features.MediatR.AdoptionRequests.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.AdoptionRequests.Handlers.Write
{
    public class CreateAdoptionRequestCommandHandler : IRequestHandler<CreateAdoptionRequestCommand, Unit>
    {
        private readonly IRepository<AdoptionRequest> _repository;
        private readonly IMapper _mapper;

        public CreateAdoptionRequestCommandHandler(IRepository<AdoptionRequest> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateAdoptionRequestCommand request, CancellationToken cancellationToken)
        {
            var adoptionRequest=_mapper.Map<AdoptionRequest>(request);
            await _repository.CreateAsync(adoptionRequest);
            return Unit.Value;
        }
    }
}
