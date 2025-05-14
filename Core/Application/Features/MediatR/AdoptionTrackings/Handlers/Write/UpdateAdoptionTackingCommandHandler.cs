using Application.Features.MediatR.AdoptionTrackings.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.AdoptionTrackings.Handlers.Write
{
    public class UpdateAdoptionTackingCommandHandler : IRequestHandler<UpdateAdoptionTrackingCommand, Unit>
    {
        private readonly IRepository<AdoptionTracking> _repository;
        private readonly IMapper _mapper;

        public UpdateAdoptionTackingCommandHandler(IRepository<AdoptionTracking> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAdoptionTrackingCommand request, CancellationToken cancellationToken)
        {
            var adoptionTracking = await _repository.GetByIdAsync(request.AdoptionTrackingId);
            _mapper.Map(request, adoptionTracking);
            _repository.UpdateAsync(adoptionTracking);
            return Unit.Value;
        }
    }
}
