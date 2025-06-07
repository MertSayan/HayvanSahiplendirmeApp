using Application.Factories;
using Application.Features.MediatR.PetImages.Commands;
using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.PetImages.Handlers.Write
{
    public class CreatePetImagesCommandHandler : IRequestHandler<CreatePetImagesCommand, Unit>
    {
        private readonly IRepository<PetImage> _repository;
        private readonly IPetImageFactory _petImageFactory;

        public CreatePetImagesCommandHandler(IRepository<PetImage> repository, IPetImageFactory petImageFactory)
        {
            _repository = repository;
            _petImageFactory = petImageFactory;
        }

        public async Task<Unit> Handle(CreatePetImagesCommand request, CancellationToken cancellationToken)
        {
            var petImages = await _petImageFactory.CreatePetImagesAsync(request.PetId, request.PetImages);

            foreach (var image in petImages)
            {
                await _repository.CreateAsync(image);
            }

            return Unit.Value;
        }
    }

}
