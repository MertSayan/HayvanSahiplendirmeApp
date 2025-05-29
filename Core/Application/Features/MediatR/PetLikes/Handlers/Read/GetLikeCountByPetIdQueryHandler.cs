using Application.Features.MediatR.PetLikes.Queries;
using Application.Features.MediatR.PetLikes.Results;
using Application.Interfaces.PetLikeInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.PetLikes.Handlers.Read
{
    public class GetLikeCountByPetIdQueryHandler : IRequestHandler<GetLikeCountByPetIdQuery, GetLikeCountByPetIdQueryResult>
    {
        private readonly IPetLikeRepository _petLikeRepository;
        private readonly IMapper _mapper;
        public GetLikeCountByPetIdQueryHandler(IPetLikeRepository petLikeRepository, IMapper mapper)
        {
            _petLikeRepository = petLikeRepository;
            _mapper = mapper;
        }

        public async Task<GetLikeCountByPetIdQueryResult> Handle(GetLikeCountByPetIdQuery request, CancellationToken cancellationToken)
        {
            var likeCount=await _petLikeRepository.GetLikeCountByPetIdAsync(request.PetId);
            return new GetLikeCountByPetIdQueryResult
            {
                LikeCount=likeCount
            };
        }
    }
}
