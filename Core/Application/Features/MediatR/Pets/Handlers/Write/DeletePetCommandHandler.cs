using Application.Features.MediatR.Pets.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.MediatR.Pets.Handlers.Write
{
    public class DeletePetCommandHandler : IRequestHandler<DeletePetCommand,Unit>
    {
        private readonly IRepository<Pet> _repository;

        public DeletePetCommandHandler(IRepository<Pet> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletePetCommand request, CancellationToken cancellationToken)
        {
            var pet = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(pet);
            return Unit.Value;
        }

       
    }
}
