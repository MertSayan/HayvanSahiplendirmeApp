using Application.Features.MediatR.AdoptionRequests.Queries;
using Application.Features.MediatR.AdoptionRequests.Results;
using Application.Interfaces.AdoptionRequestInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.AdoptionRequests.Handlers.Read
{
    public class GetAllAdoptionRequestQueryHandler : IRequestHandler<GetAllAdoptionRequestQuery, List<GetAllAdoptionRequestQueryResult>>
    {
        private readonly IAdoptionRequestRepository _adoptionRequestRepository;
        private readonly IMapper _mapper;

        public GetAllAdoptionRequestQueryHandler(IAdoptionRequestRepository adoptionRequestRepository, IMapper mapper)
        {
            _adoptionRequestRepository = adoptionRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllAdoptionRequestQueryResult>> Handle(GetAllAdoptionRequestQuery request, CancellationToken cancellationToken)
        {
            var adoptionRequest = await _adoptionRequestRepository.GetAllAdoptionRequestAsync();
            return _mapper.Map<List<GetAllAdoptionRequestQueryResult>>(adoptionRequest);
        }
    }
}
