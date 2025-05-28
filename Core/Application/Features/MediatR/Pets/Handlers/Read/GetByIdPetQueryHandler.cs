using Application.Features.MediatR.Pets.Queries;
using Application.Features.MediatR.Pets.Results;
using Application.Interfaces.PetInterface;
using Application.Interfaces.PetLikeInterface;
using AutoMapper;
using MediatR;

namespace Application.Features.MediatR.Pets.Handlers.Read
{
    public class GetByIdPetQueryHandler : IRequestHandler<GetByIdPetQuery, GetByIdPetQueryResult>
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;
        private readonly IPetLikeRepository _petLikeRepository;

        public GetByIdPetQueryHandler(IPetRepository petRepository, IMapper mapper, IPetLikeRepository petLikeRepository)
        {
            _petRepository = petRepository;
            _mapper = mapper;
            _petLikeRepository = petLikeRepository;
        }

        public async Task<GetByIdPetQueryResult> Handle(GetByIdPetQuery request, CancellationToken cancellationToken)
        {
            var pet = await _petRepository.GetByIdPetAsync(request.PetId);

            var dto= _mapper.Map<GetByIdPetQueryResult>(pet);
            dto.IsLiked= await _petLikeRepository.IsLiked(request.CurrentUserId,request.PetId);
            return dto;
        }
    }
}
