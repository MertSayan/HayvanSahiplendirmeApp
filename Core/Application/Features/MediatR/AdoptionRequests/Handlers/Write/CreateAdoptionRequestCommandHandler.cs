using Application.Enums;
using Application.Factories;
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
        private readonly IAdoptionRequestFactory _adoptionRequestFactory;

        public CreateAdoptionRequestCommandHandler(IAdoptionRequestRepository adoptionRequestRepository, IAdoptionRequestFactory adoptionRequestFactory)
        {
            _adoptionRequestRepository = adoptionRequestRepository;
            _adoptionRequestFactory = adoptionRequestFactory;
        }

        public async Task<Unit> Handle(CreateAdoptionRequestCommand request, CancellationToken cancellationToken)
        {
            var adoptionRequest = _adoptionRequestFactory.CreateAdoptionRequest(request);
            await _adoptionRequestRepository.CreateAdoptionRequestAsync(adoptionRequest);
            return Unit.Value;
        }
    }

}
