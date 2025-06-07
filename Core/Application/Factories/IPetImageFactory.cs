using Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Factories
{
    public interface IPetImageFactory
    {
        Task<List<PetImage>> CreatePetImagesAsync(int petId, List<IFormFile> files);

    }
}
