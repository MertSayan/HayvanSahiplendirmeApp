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

        public CreatePetImagesCommandHandler(IRepository<PetImage> repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(CreatePetImagesCommand request, CancellationToken cancellationToken)
        {
            var savedImagePaths = new List<string>();
            var uploadsFolderPath = Path.Combine("C:\\csharpprojeler\\HayvanSahiplendirmeApp\\FrontEnd\\HayvanWebUI", "wwwroot", "PetImage");
            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            foreach (var image in request.PetImages)
            {
                if (image != null && image.Length > 0)
                {
                    var extension = Path.GetExtension(image.FileName);
                    var uniqueName = $"{Guid.NewGuid()}{extension}";
                    var filePath = Path.Combine(uploadsFolderPath, uniqueName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    var imageEntity = new PetImage
                    {
                        PetId = request.PetId,
                        PetImageUrl = $"/PetImage/{uniqueName}"
                    };

                    await _repository.CreateAsync(imageEntity);
                }
            }
            return Unit.Value;
        }
    }
}
