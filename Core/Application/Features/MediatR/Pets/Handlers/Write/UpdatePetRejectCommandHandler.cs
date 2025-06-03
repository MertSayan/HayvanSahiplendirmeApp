using Application.Features.MediatR.Pets.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.MediatR.Pets.Handlers.Write
{
    public class UpdatePetRejectCommandHandler : IRequestHandler<UpdatePetRejectCommand, Unit>
    {
        private readonly IRepository<Pet> _repository;

        public UpdatePetRejectCommandHandler(IRepository<Pet> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdatePetRejectCommand request, CancellationToken cancellationToken)
        {
            var pet = await _repository.GetByIdAsync(request.Id);
            pet.ApprovalStatus = "Rejected";
            await _repository.UpdateAsync(pet);
            return Unit.Value;
        }
    }
}
