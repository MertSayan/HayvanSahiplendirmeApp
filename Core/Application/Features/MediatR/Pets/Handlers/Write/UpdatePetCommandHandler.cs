using Application.Features.MediatR.Pets.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.Pets.Handlers.Write
{
    public class UpdatePetCommandHandler : IRequestHandler<UpdatePetCommand, Unit>
    {
        private readonly IRepository<Pet> _repository;
        private readonly IMapper _mapper;
        public UpdatePetCommandHandler(IRepository<Pet> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
        {
            var pet = await _repository.GetByIdAsync(request.PetId);

            string mainImageUrl = pet.MainImageUrl; // varsayılan olarak mevcut yolu koru

            // Yeni fotoğraf varsa işle
            if (request.MainImageUrl != null && request.MainImageUrl.Length > 0)
            {
                // Önceki resmi sil
                if (!string.IsNullOrEmpty(pet.MainImageUrl))
                {
                    var oldImagePath = Path.Combine("C:\\Users\\furka\\Source\\Repos\\HayvanSahiplendirmeApp\\FrontEnd\\HayvanWebUI", "wwwroot", pet.MainImageUrl.TrimStart('/'));
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }

                // Yeni resmi kaydet
                var uploadsFolderPath = Path.Combine("C:\\Users\\furka\\Source\\Repos\\HayvanSahiplendirmeApp\\FrontEnd\\HayvanWebUI", "wwwroot", "PetMain");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                var extension = Path.GetExtension(request.MainImageUrl.FileName);
                var uniqueName = $"{Guid.NewGuid()}{extension}";
                var filePath = Path.Combine(uploadsFolderPath, uniqueName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.MainImageUrl.CopyToAsync(stream);
                }

                mainImageUrl = $"/PetMain/{uniqueName}";
            }

            // Tüm alanları güncelle
            _mapper.Map(request, pet);
            pet.MainImageUrl = mainImageUrl; // resim değiştiyse yeni yolu, değişmediyse eski yolu korur

            await _repository.UpdateAsync(pet);
            return Unit.Value;
        }

    }
}