using Application.Features.MediatR.AdoptionTrackings.Queries;
using Application.Features.MediatR.AdoptionTrackings.Results;
using Application.Interfaces.AdoptionTrackingInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.AdoptionTrackings.Handlers.Read
{
    public class GetAllAdoptionTrackingQueryHandler : IRequestHandler<GetAllAdoptionTrackingQuery, List<GetAllAdoptionTrackingQueryResult>>
    {
        private readonly IAdoptionTrackingRepository _adoptionTrackingRepository;
        private readonly IMapper _mapper;
        public GetAllAdoptionTrackingQueryHandler(IAdoptionTrackingRepository adoptionTrackingRepository, IMapper mapper)
        {
            _adoptionTrackingRepository = adoptionTrackingRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllAdoptionTrackingQueryResult>> Handle(GetAllAdoptionTrackingQuery request, CancellationToken cancellationToken)
        {
            var adoptionTrackings = await _adoptionTrackingRepository.GetAllAdoptionTrackingAsync();
            return _mapper.Map<List<GetAllAdoptionTrackingQueryResult>>(adoptionTrackings);
        }
    }
}
