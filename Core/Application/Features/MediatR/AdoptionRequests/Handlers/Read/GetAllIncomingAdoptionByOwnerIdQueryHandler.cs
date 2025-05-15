using Application.Features.MediatR.AdoptionRequests.Queries;
using Application.Features.MediatR.AdoptionRequests.Results;
using Application.Interfaces.AdoptionRequestInterface;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.AdoptionRequests.Handlers.Read
{
    public class GetAllIncomingAdoptionByOwnerIdQueryHandler : IRequestHandler<GetAllIncomingAdoptionByOwnerIdQuery, List<GetAllIncomingAdoptionByOwnerIdQueryResult>>
    {
        private readonly IAdoptionRequestRepository _adoptionRequestRepository;
        private readonly IMapper _mapper;
        public GetAllIncomingAdoptionByOwnerIdQueryHandler(IAdoptionRequestRepository adoptionRequestRepository, IMapper mapper)
        {
            _adoptionRequestRepository = adoptionRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllIncomingAdoptionByOwnerIdQueryResult>> Handle(GetAllIncomingAdoptionByOwnerIdQuery request, CancellationToken cancellationToken)
        {
            var adoptionRequest = await _adoptionRequestRepository.GetAllIncomingAdoptionRequestByOwnerIdAsync(request.Id);
            return _mapper.Map<List<GetAllIncomingAdoptionByOwnerIdQueryResult>>(adoptionRequest);
        }
    }
}
