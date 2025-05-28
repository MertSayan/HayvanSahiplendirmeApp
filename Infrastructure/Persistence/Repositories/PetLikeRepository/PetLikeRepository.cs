using Application.Constants;
using Application.Interfaces.PetLikeInterface;
using Azure.Core;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Xml.Linq;

namespace Persistence.Repositories.PetLikeRepository
{
    public class PetLikeRepository : IPetLikeRepository
    {
        private readonly HayvanContext _context;

        public PetLikeRepository(HayvanContext context)
        {
            _context = context;
        }

        public async Task DeletePetLikeAsync(PetLike entity)
        {
             _context.PetLikes.Remove(entity);
            await _context.SaveChangesAsync();
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

        public async Task<PetLike> GetPetLikeByIdAsync(int userId, int petId)
        {
            var petLike= await _context.PetLikes
                .FirstOrDefaultAsync(x => x.DeletedDate == null && x.UserId == userId && x.PetId == petId);
            if (petLike != null)
            {
                return petLike;
            }
            throw new Exception(Messages<PetLike>.EntityNotFound);
        }

        public async Task<bool> IsLiked(int userId, int petId)
        {
            return await _context.PetLikes.AnyAsync(x => x.PetId == petId && x.UserId == userId);
        }
    }
}
