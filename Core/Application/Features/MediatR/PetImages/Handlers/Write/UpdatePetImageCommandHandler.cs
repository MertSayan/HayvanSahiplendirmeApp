using Application.Facades.PetImageFacade;
using Application.Facades.UserFacades;
using Application.Features.MediatR.PetImages.Commands;
using Application.Features.MediatR.Users.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.MediatR.PetImages.Handlers.Write
{
    public class UpdatePetImageCommandHandler : IRequestHandler<UpdatePetImageCommand, Unit>
    {
        private readonly PetImageFacade _petImageFacade;

        public UpdatePetImageCommandHandler(PetImageFacade petImageFacade)
        {
            _petImageFacade = petImageFacade;
        }
        public async Task<Unit> Handle(UpdatePetImageCommand request, CancellationToken cancellationToken)
        {
            await _petImageFacade.UpdatePetImageAsync(request);
            return Unit.Value;
        }
    }
}
