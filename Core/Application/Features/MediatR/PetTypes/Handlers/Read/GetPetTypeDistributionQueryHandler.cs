using Application.Features.MediatR.PetTypes.Queries;
using Application.Features.MediatR.PetTypes.Results;
using Application.Interfaces.PetTypeInterface;
using MediatR;

namespace Application.Features.MediatR.PetTypes.Handlers.Read
{
    public class GetPetTypeDistributionQueryHandler : IRequestHandler<GetPetTypeDistributionQuery, List<GetPetTypeDistributionQueryResult>>
    {
        private readonly IPetTypeRepository _petTypeRepository;

        public GetPetTypeDistributionQueryHandler(IPetTypeRepository petTypeRepository)
        {
            _petTypeRepository = petTypeRepository;
        }


        public Task<List<GetPetTypeDistributionQueryResult>> Handle(GetPetTypeDistributionQuery request, CancellationToken cancellationToken)
        {
            return _petTypeRepository.GetPetTypeDistributionAsync();
        }
    }
}
