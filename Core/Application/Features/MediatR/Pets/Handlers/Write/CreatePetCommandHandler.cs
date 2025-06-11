using Application.Events;
using Application.Facades.PetFacades;
using Application.Factories;
using Application.Features.MediatR.Pets.Commands;
using Application.Interfaces;
using Application.Observers;
using AutoMapper;
using Domain;
using MassTransit;
using MediatR;

namespace Application.Features.MediatR.Pets.Handlers.Write
{
    public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, Unit>
    {
        private readonly PetFacade _petFacade;

        public CreatePetCommandHandler(PetFacade petFacade)
        {
            _petFacade = petFacade;
        }

        public async Task<Unit> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            await _petFacade.CreatePetAsync(request);
            return Unit.Value;
        }
    }


}
