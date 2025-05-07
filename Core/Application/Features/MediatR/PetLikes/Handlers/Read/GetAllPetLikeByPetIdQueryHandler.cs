using Application.Features.MediatR.PetLikes.Queries;
using Application.Features.MediatR.PetLikes.Results;
using Application.Interfaces.PetLikeInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.PetLikes.Handlers.Read
{
    public class GetAllPetLikeByPetIdQueryHandler : IRequestHandler<GetAllPetLikeByPetIdQuery, List<GetAllPetLikeByPetIdQueryResult>>
    {
        private readonly IPetLikeRepository _petLikeRepository;
        private readonly IMapper _mapper;

        public GetAllPetLikeByPetIdQueryHandler(IPetLikeRepository petLikeRepository, IMapper mapper)
        {
            _petLikeRepository = petLikeRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllPetLikeByPetIdQueryResult>> Handle(GetAllPetLikeByPetIdQuery request, CancellationToken cancellationToken)
        {
            var petLikes = await _petLikeRepository.GetAllPetLikeByPetIdAsync(request.Id);
            return _mapper.Map<List<GetAllPetLikeByPetIdQueryResult>>(petLikes);
        }
    }
}
