using Application.Interfaces.PetLikeInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.PetLikeRepository
{
    public class PetLikeRepository : IPetLikeRepository
    {
        private readonly HayvanContext _context;

        public PetLikeRepository(HayvanContext context)
        {
            _context = context;
        }

        public async Task<List<PetLike>> GetAllPetLikeByPetIdAsync(int id)
        {
            return await _context.PetLikes.Where(x => x.DeletedDate == null && x.PetId == id)
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<List<PetLike>> GetAllPetLikeByUserIdAsync(int id)
        {
            return await _context.PetLikes.Where(x => x.DeletedDate == null && x.UserId == id)
               .Include(x => x.Pet)
               .ToListAsync();
        }
    }
}
