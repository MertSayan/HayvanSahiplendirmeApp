using Application.Factories;
using Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Factories
{
    public class PetImageFactory : IPetImageFactory
    {
        public async Task<List<PetImage>> CreatePetImagesAsync(int petId, List<IFormFile> files)
        {
            var petImages = new List<PetImage>();
            var uploadsFolderPath = Path.Combine("C:\\Users\\baris\\source\\repos\\HayvanSahiplendirmeApp\\FrontEnd\\HayvanWebUI", "wwwroot", "PetImage");

            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            foreach (var image in files)
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
                        PetId = petId,
                        PetImageUrl = $"/PetImage/{uniqueName}"
                    };

                    petImages.Add(imageEntity);
                }
            }

            return petImages;
        }
    }
}
