using Application.Events;
using Application.Factories;
using Application.Features.MediatR.Pets.Commands;
using Application.Interfaces;
using Application.Observers;
using AutoMapper;
using Domain;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Facades.PetFacades
{
    public class PetFacade
    {
        private readonly IRepository<Pet> _repository;
        private readonly IPetFactory _petFactory;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IEnumerable<IPetCreatedObserver> _observers;
        private readonly IMapper _mapper;

        public PetFacade(
            IRepository<Pet> repository,
            IPetFactory petFactory,
            IPublishEndpoint publishEndpoint,
            IEnumerable<IPetCreatedObserver> observers,
            IMapper mapper)
        {
            _repository = repository;
            _petFactory = petFactory;
            _publishEndpoint = publishEndpoint;
            _observers = observers;
            _mapper = mapper;
        }

        public async Task CreatePetAsync(CreatePetCommand request)
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

            await _publishEndpoint.Publish(petCreatedEvent);

            foreach (var observer in _observers)
            {
                await observer.OnPetCreatedAsync(petCreatedEvent);
            }
        }

        public async Task UpdatePetAsync(UpdatePetCommand request)
        {
            var pet = await _repository.GetByIdAsync(request.PetId);
            string mainImageUrl = pet.MainImageUrl;

            if (request.MainImageUrl != null && request.MainImageUrl.Length > 0)
            {
                if (!string.IsNullOrEmpty(pet.MainImageUrl))
                {
                    var oldImagePath = Path.Combine("C:\\Users\\baris\\Source\\Repos\\HayvanSahiplendirmeApp\\FrontEnd\\HayvanWebUI", "wwwroot", pet.MainImageUrl.TrimStart('/'));
                    if (File.Exists(oldImagePath))
                        File.Delete(oldImagePath);
                }

                var uploadsFolderPath = Path.Combine("C:\\Users\\baris\\Source\\Repos\\HayvanSahiplendirmeApp\\FrontEnd\\HayvanWebUI", "wwwroot", "PetMain");
                if (!Directory.Exists(uploadsFolderPath))
                    Directory.CreateDirectory(uploadsFolderPath);

                var extension = Path.GetExtension(request.MainImageUrl.FileName);
                var uniqueName = $"{Guid.NewGuid()}{extension}";
                var filePath = Path.Combine(uploadsFolderPath, uniqueName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await request.MainImageUrl.CopyToAsync(stream);

                mainImageUrl = $"/PetMain/{uniqueName}";
            }

            _mapper.Map(request, pet);
            pet.MainImageUrl = mainImageUrl;

            await _repository.UpdateAsync(pet);
        }
    }
}

