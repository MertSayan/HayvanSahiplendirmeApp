using Application.Features.MediatR.PetLikes.Queries;
using Application.Features.MediatR.PetLikes.Results;
using Application.Interfaces.PetLikeInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.PetLikes.Handlers.Read
{
    public class GetAllPetLikeByUserIdQueryHandler : IRequestHandler<GetAllPetLikeByUserIdQuery, List<GetAllPetLikeByUserIdQueryResult>>
    {
        private readonly IPetLikeRepository _petLikeRepository;
        private readonly IMapper _mapper;
        public GetAllPetLikeByUserIdQueryHandler(IPetLikeRepository petLikeRepository, IMapper mapper)
        {
            _petLikeRepository = petLikeRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllPetLikeByUserIdQueryResult>> Handle(GetAllPetLikeByUserIdQuery request, CancellationToken cancellationToken)
        {
            var petLikes = await _petLikeRepository.GetAllPetLikeByUserIdAsync(request.Id);
            return _mapper.Map<List<GetAllPetLikeByUserIdQueryResult>>(petLikes);
        }
    }
}
