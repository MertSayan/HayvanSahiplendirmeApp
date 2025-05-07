using Application.Features.MediatR.PetLikes.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.PetLikes.Handlers.Write
{
    public class UpdatePetLikeCommandHandler : IRequestHandler<UpdatePetLikeCommand, Unit>
    {
        private readonly IRepository<PetLike> _repository;
        private readonly IMapper _mapper;
        public UpdatePetLikeCommandHandler(IRepository<PetLike> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePetLikeCommand request, CancellationToken cancellationToken)
        {
            var petLike=await _repository.GetByIdAsync(request.PetLikeId);
            _mapper.Map(request,petLike);
            await _repository.UpdateAsync(petLike);
            return Unit.Value;
        }
    }
}
