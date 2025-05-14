using Application.Features.MediatR.AdoptionTrackings.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.AdoptionTrackings.Handlers.Write
{
    public class CreateAdoptionTrackingCommandHandler : IRequestHandler<CreateAdoptionTrackingCommand, Unit>
    {
        private readonly IRepository<AdoptionTracking> _repository;
        private readonly IMapper _mapper;
        public CreateAdoptionTrackingCommandHandler(IRepository<AdoptionTracking> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateAdoptionTrackingCommand request, CancellationToken cancellationToken)
        {
            var adoptionTracking = _mapper.Map<AdoptionTracking>(request);
            await _repository.CreateAsync(adoptionTracking);
            return Unit.Value;
        }
    }
}
