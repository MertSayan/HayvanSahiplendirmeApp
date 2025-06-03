using Application.Features.MediatR.Pets.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.MediatR.Pets.Handlers.Write
{
    public class UpdatePetAcceptCommandHandler : IRequestHandler<UpdatePetAcceptCommand, Unit>
    {
        private readonly IRepository<Pet> _repository;

        public UpdatePetAcceptCommandHandler(IRepository<Pet> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdatePetAcceptCommand request, CancellationToken cancellationToken)
        {
            var pet = await _repository.GetByIdAsync(request.Id);
            pet.ApprovalStatus = "Accepted";
            await _repository.UpdateAsync(pet);
            return Unit.Value;
        }
    }
}
