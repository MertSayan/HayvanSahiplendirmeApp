using Application.Events;
using Application.Observers;
using MassTransit;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Net.Mail;

namespace WebApi.Consumer
{
    public class PetCreatedEventConsumer : IConsumer<PetCreatedEvent>
    {
        private readonly IEnumerable<IPetCreatedObserver> _observers;

        public PetCreatedEventConsumer(IEnumerable<IPetCreatedObserver> observers)
        {
            _observers = observers;
        }

        public async Task Consume(ConsumeContext<PetCreatedEvent> context)
        {
            var pet = context.Message;

            foreach (var observer in _observers)
            {
                await observer.OnPetCreatedAsync(pet);
            }
        }
    }
}
