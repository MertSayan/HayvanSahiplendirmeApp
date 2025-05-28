using Application.Interfaces.PetImageInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.PetImageRepository
{
    public class PetImageRepository : IPetImageRepository
    {
        private readonly HayvanContext _context;

        public PetImageRepository(HayvanContext context)
        {
            _context = context;
        }

        public async Task<List<PetImage>> GetAllPetImageByPetId(int id)
        {
            return await _context.PetImages.Where(x=>x.DeletedDate==null && x.PetId==id)
                .ToListAsync();
        }
    }
}
