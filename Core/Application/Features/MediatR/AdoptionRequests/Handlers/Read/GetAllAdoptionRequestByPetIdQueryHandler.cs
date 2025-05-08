using Application.Features.MediatR.AdoptionRequests.Queries;
using Application.Features.MediatR.AdoptionRequests.Results;
using Application.Interfaces.AdoptionRequestInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.AdoptionRequests.Handlers.Read
{
    public class GetAllAdoptionRequestByPetIdQueryHandler : IRequestHandler<GetAllAdoptionRequestByPetIdQuery, List<GetAllAdoptionRequestByPetIdQueryResult>>
    {
        private readonly IAdoptionRequestRepository _adoptionRequestRepository;
        private readonly IMapper _mapper;
        public GetAllAdoptionRequestByPetIdQueryHandler(IAdoptionRequestRepository adoptionRequestRepository, IMapper mapper)
        {
            _adoptionRequestRepository = adoptionRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllAdoptionRequestByPetIdQueryResult>> Handle(GetAllAdoptionRequestByPetIdQuery request, CancellationToken cancellationToken)
        {
            var adoptionRequest = await _adoptionRequestRepository.GetAllAdoptionRequestByPetIdAsync(request.Id);
            return _mapper.Map<List<GetAllAdoptionRequestByPetIdQueryResult>>(adoptionRequest);
        }
    }
}
