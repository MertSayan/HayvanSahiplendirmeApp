using Application.Features.MediatR.AdoptionTrackings.Queries;
using Application.Features.MediatR.AdoptionTrackings.Results;
using Application.Interfaces.AdoptionTrackingInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.AdoptionTrackings.Handlers.Read
{
    public class GetByIdAdoptionTrackingQueryHandler : IRequestHandler<GetByIdAdoptionTrackingQuery, GetByIdAdoptionTrackingQueryResult>
    {
        private readonly IAdoptionTrackingRepository _adoptionTrackingRepository;
        private readonly IMapper _mapper;
        public GetByIdAdoptionTrackingQueryHandler(IAdoptionTrackingRepository adoptionTrackingRepository, IMapper mapper)
        {
            _adoptionTrackingRepository = adoptionTrackingRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdAdoptionTrackingQueryResult> Handle(GetByIdAdoptionTrackingQuery request, CancellationToken cancellationToken)
        {
            var adoptionTracking = await _adoptionTrackingRepository.GetByIdAdoptionTrackingAsync(request.Id);
            return _mapper.Map<GetByIdAdoptionTrackingQueryResult>(adoptionTracking);
        }
    }
}
