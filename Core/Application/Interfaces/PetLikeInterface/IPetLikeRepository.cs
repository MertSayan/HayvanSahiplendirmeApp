using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.PetLikeInterface
{
    public interface IPetLikeRepository
    {
        Task<List<PetLike>> GetAllPetLikeByPetIdAsync(int id);
        Task<List<PetLike>> GetAllPetLikeByUserIdAsync(int id);
        
    }
}
