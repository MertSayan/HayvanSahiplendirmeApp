using Application.Facades.PetFacades;
using Application.Features.MediatR.Pets.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.Pets.Handlers.Write
{
    public class UpdatePetCommandHandler : IRequestHandler<UpdatePetCommand, Unit>
    {
        private readonly PetFacade _petFacade;

        public UpdatePetCommandHandler(PetFacade petFacade)
        {
            _petFacade = petFacade;
        }

        public async Task<Unit> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
        {
            await _petFacade.UpdatePetAsync(request);
            return Unit.Value;
        }

    }
}