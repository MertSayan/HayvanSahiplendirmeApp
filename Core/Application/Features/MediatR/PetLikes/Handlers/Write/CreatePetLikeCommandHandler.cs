using Application.Features.MediatR.PetLikes.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.PetLikes.Handlers.Write
{
    public class CreatePetLikeCommandHandler : IRequestHandler<CreatePetLikeCommand, Unit>
    {
        private readonly IRepository<PetLike> _repository;
        private readonly IMapper _mapper;

        public CreatePetLikeCommandHandler(IRepository<PetLike> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreatePetLikeCommand request, CancellationToken cancellationToken)
        {
            var petLike=_mapper.Map<PetLike>(request);
            await _repository.CreateAsync(petLike);
            return Unit.Value;
        }
    }
}
