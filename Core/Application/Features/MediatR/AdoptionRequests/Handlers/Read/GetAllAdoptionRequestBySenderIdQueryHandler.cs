using Application.Features.MediatR.AdoptionRequests.Queries;
using Application.Features.MediatR.AdoptionRequests.Results;
using Application.Interfaces.AdoptionRequestInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.AdoptionRequests.Handlers.Read
{
    //bunu profildeki sahiplenme isteğinde bulunduğum hayvanlar için yazdım.
    public class GetAllAdoptionRequestBySenderIdQueryHandler : IRequestHandler<GetAllAdoptionRequestBySenderIdQuery, List<GetAllAdoptionRequestBySenderIdQueryResult>>
    {
        private readonly IAdoptionRequestRepository _adoptionRequestRepository;
        private readonly IMapper _mapper;
        public GetAllAdoptionRequestBySenderIdQueryHandler(IAdoptionRequestRepository adoptionRequestRepository, IMapper mapper)
        {
            _adoptionRequestRepository = adoptionRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllAdoptionRequestBySenderIdQueryResult>> Handle(GetAllAdoptionRequestBySenderIdQuery request, CancellationToken cancellationToken)
        {
            var adoptionRequests=await _adoptionRequestRepository.GetAllAdoptionRequestBySenderId(request.Id);
            return _mapper.Map<List<GetAllAdoptionRequestBySenderIdQueryResult>>(adoptionRequests);
        }
    }
}
