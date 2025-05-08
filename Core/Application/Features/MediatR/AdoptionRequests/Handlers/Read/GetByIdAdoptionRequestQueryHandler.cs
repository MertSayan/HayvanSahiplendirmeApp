using Application.Features.MediatR.AdoptionRequests.Queries;
using Application.Features.MediatR.AdoptionRequests.Results;
using Application.Interfaces.AdoptionRequestInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.AdoptionRequests.Handlers.Read
{
    public class GetByIdAdoptionRequestQueryHandler : IRequestHandler<GetByIdAdoptionRequestQuery, GetByIdAdoptionRequestQueryResult>
    {
        private readonly IAdoptionRequestRepository _adoptionRequestRepository;
        private readonly IMapper _mapper;

        public GetByIdAdoptionRequestQueryHandler(IAdoptionRequestRepository adoptionRequestRepository, IMapper mapper)
        {
            _adoptionRequestRepository = adoptionRequestRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdAdoptionRequestQueryResult> Handle(GetByIdAdoptionRequestQuery request, CancellationToken cancellationToken)
        {
            var pet = await _adoptionRequestRepository.GetByIdAdoptionRequest(request.Id);
            return _mapper.Map<GetByIdAdoptionRequestQueryResult>(pet);
        }
    }
    
}
