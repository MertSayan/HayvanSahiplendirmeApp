using Application.Features.MediatR.AdoptionTrackings.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.MediatR.AdoptionTrackings.Handlers.Write
{
    public class DeleteAdoptionTrackingCommandHandler : IRequestHandler<DeleteAdoptionTrackingCommand, Unit>
    {
        private readonly IRepository<AdoptionTracking> _repository;

        public DeleteAdoptionTrackingCommandHandler(IRepository<AdoptionTracking> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAdoptionTrackingCommand request, CancellationToken cancellationToken)
        {
            var adoptionTracking = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(adoptionTracking);
            return Unit.Value;
        }
    }
}
