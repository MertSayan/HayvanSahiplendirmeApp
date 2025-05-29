using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.PetImageInterface
{
    public interface IPetImageRepository
    {
        Task<List<PetImage>> GetAllPetImageByPetId(int id);
    }
}
