using Application.Features.MediatR.AdoptionRequests.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.AdoptionRequests.Handlers.Write
{
    public class DeleteAdoptionRequestCommandHandler : IRequestHandler<DeleteAdoptionRequestCommand, Unit>
    {
        private readonly IRepository<AdoptionRequest> _repository;
        public DeleteAdoptionRequestCommandHandler(IRepository<AdoptionRequest> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAdoptionRequestCommand request, CancellationToken cancellationToken)
        {
            var adoptionRequest = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(adoptionRequest);
            return Unit.Value;
        }
    }
}
