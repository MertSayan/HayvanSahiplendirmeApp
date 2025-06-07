using Application.Factories;
using Application.Features.MediatR.Pets.Commands;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Factories
{
    public class PetFactory : IPetFactory
    {
        private readonly IMapper _mapper;

        public PetFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Pet> CreatePetAsync(CreatePetCommand request)
        {
            var pet = _mapper.Map<Pet>(request);

            if (request.MainImageUrl != null && request.MainImageUrl.Length > 0)
            {
                var uploadsFolderPath = Path.Combine("C:\\Users\\baris\\source\\repos\\HayvanSahiplendirmeApp\\FrontEnd\\HayvanWebUI", "wwwroot", "PetMain");

                if (!Directory.Exists(uploadsFolderPath))
                    Directory.CreateDirectory(uploadsFolderPath);

                var fileExtension = Path.GetExtension(request.MainImageUrl.FileName);
                var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                var filePath = Path.Combine(uploadsFolderPath, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.MainImageUrl.CopyToAsync(fileStream);
                }

                pet.MainImageUrl = $"/PetMain/{uniqueFileName}";
            }

            pet.ApprovalStatus = "Pending";

            return pet;
        }
    }
}
