using Application.Enums;
using Application.Features.MediatR.AdoptionRequests.Commands;
using Application.Features.MediatR.AdoptionTrackings.Handlers.Write;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.AdoptionRequests.Handlers.Write
{
    public class UpdateAdoptionRequestAccpetCommandHandler : IRequestHandler<UpdateAdoptionRequestAcceptCommand, Unit>
    {
        private readonly IRepository<AdoptionRequest> _repository;
        private readonly IMapper _mapper;
        public UpdateAdoptionRequestAccpetCommandHandler(IRepository<AdoptionRequest> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAdoptionRequestAcceptCommand request, CancellationToken cancellationToken)
        {
            var adoptionRequest = await _repository.GetByIdAsync(request.Id);
            adoptionRequest.Status=AdoptionStatus.Accepted.ToString();
            await _repository.UpdateAsync(adoptionRequest);
            return Unit.Value;
        }
    }
}
