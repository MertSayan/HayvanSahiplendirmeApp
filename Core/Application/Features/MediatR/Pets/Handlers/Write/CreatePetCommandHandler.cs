using Application.Factories;
using Application.Features.MediatR.Pets.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.Pets.Handlers.Write
{
    public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, Unit>
    {
        private readonly IRepository<Pet> _repository;
        private readonly IPetFactory _petFactory;

        public CreatePetCommandHandler(IRepository<Pet> repository, IPetFactory petFactory)
        {
            _repository = repository;
            _petFactory = petFactory;
        }

        public async Task<Unit> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            var pet = await _petFactory.CreatePetAsync(request);
            await _repository.CreateAsync(pet);
            return Unit.Value;
        }
    }

}
