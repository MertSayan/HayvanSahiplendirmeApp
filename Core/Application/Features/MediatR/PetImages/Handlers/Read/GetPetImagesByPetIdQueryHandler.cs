using Application.Features.MediatR.PetImages.Queries;
using Application.Features.MediatR.PetImages.Results;
using Application.Interfaces.PetImageInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.PetImages.Handlers.Read
{
    public class GetPetImagesByPetIdQueryHandler : IRequestHandler<GetPetImagesByPetIdQuery, List<GetPetImagesByPetIdQueryResult>>
    {
        private readonly IPetImageRepository _petImageRepository;
        private readonly IMapper _mapper;
        public GetPetImagesByPetIdQueryHandler(IPetImageRepository petRepository, IMapper mapper)
        {
            _petImageRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<List<GetPetImagesByPetIdQueryResult>> Handle(GetPetImagesByPetIdQuery request, CancellationToken cancellationToken)
        {
            var petImages = await _petImageRepository.GetAllPetImageByPetId(request.Id);
            return _mapper.Map<List<GetPetImagesByPetIdQueryResult>>(petImages);    
        }
    }
}
