using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.PetFavoritesInterface
{
    public interface IPetFavoritesRepository
    {
        Task<List<Pet>> GetMyPetFavoritesAsync(int userId);
    }
}
