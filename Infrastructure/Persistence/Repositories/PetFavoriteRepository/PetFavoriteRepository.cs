using Application.Features.MediatR.AdoptionRequests.Queries;
using Application.Interfaces.PetFavoritesInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.PetFavoriteRepository
{
    public class PetFavoriteRepository : IPetFavoritesRepository
    {
        private readonly HayvanContext _context;

        public PetFavoriteRepository(HayvanContext context)
        {
            _context = context;
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
    }
}
