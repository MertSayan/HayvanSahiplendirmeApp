using Application.Features.MediatR.PetLikes.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.PetLikes.Handlers.Write
{
    public class DeletePetLikeCommandHandler : IRequestHandler<DeletePetLikeCommand, Unit>
    {
        private readonly IRepository<PetLike> _repository;
        private readonly IMapper _mapper;
        public DeletePetLikeCommandHandler(IRepository<PetLike> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePetLikeCommand request, CancellationToken cancellationToken)
        {
            var petLike=await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(petLike);
            return Unit.Value;
        }
    }
}
