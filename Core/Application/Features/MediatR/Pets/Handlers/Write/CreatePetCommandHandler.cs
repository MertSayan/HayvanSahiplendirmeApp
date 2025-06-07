using Application.Events;
using Application.Factories;
using Application.Features.MediatR.Pets.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MassTransit;
using MediatR;

namespace Application.Features.MediatR.Pets.Handlers.Write
{
    public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, Unit>
    {
        private readonly IRepository<Pet> _repository;
        private readonly IPetFactory _petFactory;
        private readonly IPublishEndpoint _publishEndpoint;

        public CreatePetCommandHandler(
            IRepository<Pet> repository,
            IPetFactory petFactory,
            IPublishEndpoint publishEndpoint)
        {
            _repository = repository;
            _petFactory = petFactory;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Unit> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            var pet = await _petFactory.CreatePetAsync(request);
            await _repository.CreateAsync(pet);

            var petWithUser = await _repository.GetByFilterAsync(
               x => x.PetId == pet.PetId,
               x => x.User
           );
            if (petWithUser?.User?.Email == null)
                throw new Exception("İlan sahibi kullanıcının e-posta adresi bulunamadı.");
            // Event yayınla
            await _publishEndpoint.Publish(new PetCreatedEvent
            {
                PetId = petWithUser.PetId,
                PetName = petWithUser.Name,
                UserEmail = petWithUser.User.Email
            });

            return Unit.Value;
        }
    }


}
