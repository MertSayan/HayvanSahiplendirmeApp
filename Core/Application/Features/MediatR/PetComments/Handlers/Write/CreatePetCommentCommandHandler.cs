using Application.Features.MediatR.PetComments.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.PetComments.Handlers.Write
{
    public class CreatePetCommentCommandHandler : IRequestHandler<CreatePetCommentCommand, Unit>
    {
        private readonly IRepository<PetComment> _repository;
        private readonly IMapper _mapper;

        public CreatePetCommentCommandHandler(IRepository<PetComment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreatePetCommentCommand request, CancellationToken cancellationToken)
        {
            var petComment = _mapper.Map<PetComment>(request);
            await _repository.CreateAsync(petComment);
            return Unit.Value;
        }
    }
}
