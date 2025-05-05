using Application.Features.MediatR.Pets.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.Pets.Handlers.Write
{
    public class UpdatePetCommandHandler : IRequestHandler<UpdatePetCommand,Unit>
    {
        private readonly IRepository<Pet> _repository;
        private readonly IMapper _mapper;
        public UpdatePetCommandHandler(IRepository<Pet> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
        {
            var pet = await _repository.GetByIdAsync(request.PetId);
            _mapper.Map(request, pet); //request deki verileri pet e uygular.
            await _repository.UpdateAsync(pet);
            return Unit.Value;
        }
    }
}
