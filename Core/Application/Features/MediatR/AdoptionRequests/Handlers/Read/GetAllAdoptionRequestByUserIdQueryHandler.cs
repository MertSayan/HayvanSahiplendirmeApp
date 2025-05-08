using Application.Features.MediatR.AdoptionRequests.Queries;
using Application.Features.MediatR.AdoptionRequests.Results;
using Application.Interfaces.AdoptionRequestInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.AdoptionRequests.Handlers.Read
{
    public class GetAllAdoptionRequestByUserIdQueryHandler : IRequestHandler<GetAllAdoptionRequestByUserIdQuery, List<GetAllAdoptionRequestByUserIdQueryResult>>
    {
        private readonly IAdoptionRequestRepository _adoptionRequestRepository;
        private readonly IMapper _mapper;

        public GetAllAdoptionRequestByUserIdQueryHandler(IAdoptionRequestRepository adoptionRequestRepository, IMapper mapper)
        {
            _adoptionRequestRepository = adoptionRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllAdoptionRequestByUserIdQueryResult>> Handle(GetAllAdoptionRequestByUserIdQuery request, CancellationToken cancellationToken)
        {
            var adoptionRequest = await _adoptionRequestRepository.GetAllAdoptionRequestByUserIdAsync(request.Id);
            return _mapper.Map<List<GetAllAdoptionRequestByUserIdQueryResult>>(adoptionRequest);
        }
    }
}
