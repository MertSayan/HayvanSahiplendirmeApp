using Application.Features.MediatR.PetImages.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.MediatR.PetImages.Handlers.Write
{
    public class UpdatePetImageCommandHandler : IRequestHandler<UpdatePetImageCommand, Unit>
    {
        private readonly IRepository<PetImage> _repository;

        public UpdatePetImageCommandHandler(IRepository<PetImage> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdatePetImageCommand request, CancellationToken cancellationToken)
        {
            var imageEntity = await _repository.GetByIdAsync(request.PetImageId);
            if (imageEntity == null)
                throw new Exception("Fotoğraf kaydı bulunamadı.");

            // Önce eski resmi sil (varsa)
            if (!string.IsNullOrEmpty(imageEntity.PetImageUrl))
            {
                var oldImagePath = Path.Combine("C:\\Users\\furka\\Source\\Repos\\HayvanSahiplendirmeApp\\FrontEnd\\HayvanWebUI", "wwwroot", imageEntity.PetImageUrl.TrimStart('/'));
                if (File.Exists(oldImagePath))
                {
                    File.Delete(oldImagePath);
                }
            }

            // Yeni resmi kaydet
            if (request.PetImage != null && request.PetImage.Length > 0)
            {
                var uploadsFolderPath = Path.Combine("C:\\Users\\furka\\Source\\Repos\\HayvanSahiplendirmeApp\\FrontEnd\\HayvanWebUI", "wwwroot", "PetImage");
                if (!Directory.Exists(uploadsFolderPath))
                    Directory.CreateDirectory(uploadsFolderPath);

                var extension = Path.GetExtension(request.PetImage.FileName);
                var uniqueName = $"{Guid.NewGuid()}{extension}";
                var filePath = Path.Combine(uploadsFolderPath, uniqueName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.PetImage.CopyToAsync(stream);
                }

                // Yeni yolu veritabanına yaz
                imageEntity.PetImageUrl = $"/PetImage/{uniqueName}";
                await _repository.UpdateAsync(imageEntity);
            }

            return Unit.Value;
        }
    }
}
