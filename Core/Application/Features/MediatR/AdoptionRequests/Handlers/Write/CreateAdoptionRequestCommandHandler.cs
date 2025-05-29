using Application.Enums;
using Application.Features.MediatR.AdoptionRequests.Commands;
using Application.Interfaces.AdoptionRequestInterface;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.AdoptionRequests.Handlers.Write
{
    public class CreateAdoptionRequestCommandHandler : IRequestHandler<CreateAdoptionRequestCommand, Unit>
    {
        private readonly IAdoptionRequestRepository _adoptionRequestRepository;
        private readonly IMapper _mapper;

        public CreateAdoptionRequestCommandHandler(IAdoptionRequestRepository adoptionRequestRepository, IMapper mapper)
        {
            _adoptionRequestRepository = adoptionRequestRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateAdoptionRequestCommand request, CancellationToken cancellationToken)
        {
            var adoptionRequest=_mapper.Map<AdoptionRequest>(request);
            adoptionRequest.Status = AdoptionStatus.Pending.ToString();
            await _adoptionRequestRepository.CreateAdoptionRequestAsync(adoptionRequest);
            return Unit.Value;
        }
    }
}
