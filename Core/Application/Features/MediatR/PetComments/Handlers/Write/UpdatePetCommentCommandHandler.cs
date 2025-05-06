using Application.Features.MediatR.PetComments.Commands;
using Application.Features.MediatR.Pets.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.PetComments.Handlers.Write
{
    public class UpdatePetCommentCommandHandler : IRequestHandler<UpdatePetCommentCommand, Unit>
    {
        private readonly IRepository<PetComment> _repository;
        private readonly IMapper _mapper;
        public UpdatePetCommentCommandHandler(IRepository<PetComment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePetCommentCommand request, CancellationToken cancellationToken)
        {
            var pet = await _repository.GetByIdAsync(request.PetCommentId);
            _mapper.Map(request, pet); //request deki verileri pet e uygular.
            await _repository.UpdateAsync(pet);
            return Unit.Value;
        }
    }
}
