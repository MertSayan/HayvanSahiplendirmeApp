using Application.Constants;
using Application.Interfaces.PetFavoritesInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.PetFavoriteRepository
{
    public class PetFavoriteRepository : IPetFavoritesRepository
    {
        private readonly HayvanContext _context;

        public PetFavoriteRepository(HayvanContext context)
        {
            _context = context;
        }

        public async Task DeletePetFavoriteAsync(PetFavorite entity)
        {
            _context.PetFavorites.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Pet>> GetMyPetFavoritesAsync(int userId)
        {
            var favoritePetIds = await _context.PetFavorites
                .Where(x => x.UserId == userId && x.DeletedDate == null)
                .Select(f => f.PetId)
                .ToListAsync();

            return await _context.Pets
                .Where(p => favoritePetIds.Contains(p.PetId) && p.DeletedDate == null)
                .Include(p => p.PetType)
                .Include(p => p.PetLikes)
                .Include(p => p.PetComments)
                .ToListAsync();

        }

        public async Task<PetFavorite> GetPetFavoriteByIdAsync(int userId, int petId)
        {
            var petFavorite = await _context.PetFavorites
               .FirstOrDefaultAsync(x => x.DeletedDate == null && x.UserId == userId && x.PetId == petId);
            if (petFavorite != null)
            {
                return petFavorite;
            }
            throw new Exception(Messages<PetFavorite>.EntityNotFound);
        }
    }
}
