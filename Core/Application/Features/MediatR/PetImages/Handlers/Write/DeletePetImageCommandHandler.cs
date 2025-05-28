using Application.Features.MediatR.PetImages.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.MediatR.PetImages.Handlers.Write
{
    public class DeletePetImageCommandHandler:IRequestHandler<DeletePetImageCommand,Unit>
    {
        private readonly IRepository<PetImage> _repository;

        public DeletePetImageCommandHandler(IRepository<PetImage> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeletePetImageCommand request, CancellationToken cancellationToken)
        {
            var imageEntity = await _repository.GetByIdAsync(request.Id);
            if (imageEntity == null)
                throw new Exception("Silinecek fotoğraf bulunamadı.");

            // Fiziksel dosya yolunu oluştur
            if (!string.IsNullOrEmpty(imageEntity.PetImageUrl))
            {
                var filePath = Path.Combine("C:\\csharpprojeler\\HayvanSahiplendirmeApp\\FrontEnd\\HayvanWebUI", "wwwroot", imageEntity.PetImageUrl.TrimStart('/'));
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            // Veritabanından kaydı sil
            await _repository.DeleteAsync(imageEntity);
            return Unit.Value;
        }
    }
}
