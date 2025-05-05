using Application.Interfaces.PetInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.PetRepository
{
    public class PetRepository : IPetRepository
    {
        private readonly HayvanContext _context;

        public PetRepository(HayvanContext context)
        {
            _context = context;
        }

        public async Task<List<Pet>> GetAllPetAsync()
        {
            return await _context.Pets.Where(x=>x.DeletedDate==null)
                .Include(x=>x.User)
                .Include(x=>x.PetType)
                .ToListAsync();
        }

        public async Task<Pet> GetByIdPetAsync(int id)
        {
            var entity = await _context.Pets
               .Include(p => p.User)
               .Include(p => p.PetType)
               .FirstOrDefaultAsync(p => p.PetId == id && p.DeletedDate == null);

            if (entity == null)
                throw new Exception("Pet bulunamadı.");
            return entity;
        }
    }
}
