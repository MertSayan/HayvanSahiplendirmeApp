using Application.Events;
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
        private readonly IRepository<Pet> _repository;
        private readonly IPetFactory _petFactory;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IEnumerable<IPetCreatedObserver> _observers;


        public CreatePetCommandHandler(
            IRepository<Pet> repository,
            IPetFactory petFactory,
            IPublishEndpoint publishEndpoint,
            IEnumerable<IPetCreatedObserver> observers)
        {
            _repository = repository;
            _petFactory = petFactory;
            _publishEndpoint = publishEndpoint;
            _observers = observers;
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


            var petCreatedEvent = new PetCreatedEvent
            {
                PetId = petWithUser.PetId,
                PetName = petWithUser.Name,
                UserEmail = petWithUser.User.Email
            };

            // EventBus (MassTransit) ile yayınla
            await _publishEndpoint.Publish(petCreatedEvent);

            // Observer'lara bildir
            foreach (var observer in _observers)
            {
                await observer.OnPetCreatedAsync(petCreatedEvent);
            }

            return Unit.Value;
        }
    }


}
