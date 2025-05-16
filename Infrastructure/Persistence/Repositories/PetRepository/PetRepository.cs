using Application.Constants;
using Application.Features.MediatR.Pets.Results;
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

        public async Task<List<Pet>> GetAllActivePetByOwnerIdAsync(int ownerId)
        {
            return await _context.Pets.Where(x=>x.DeletedDate==null && x.UserId==ownerId && x.IsAdopted==false)
                .Include(x=>x.PetType)
                .Include(x=>x.PetLikes)
                .Include(x=>x.PetComments)
                .ToListAsync();
        }

        public async Task<List<Pet>> GetAllAdoptedPetByOwnerIdAsync(int ownerId)
        {
            return await _context.Pets.Where(x => x.DeletedDate == null && x.UserId == ownerId && x.IsAdopted == true)
                .Include(x => x.PetType)
                .ToListAsync();
        }

        public async Task<List<Pet>> GetAllPetAsync()
        {
            return await _context.Pets.Where(x=>x.DeletedDate==null)
                .Include(x=>x.User)
                .Include(x=>x.PetType)
                .ToListAsync();
        }

        public async Task<List<Pet>> GetAllPetByOwnerIdAsync(int ownerId)
        {
            return await _context.Pets
             .Where(p => p.UserId == ownerId && p.DeletedDate == null)
             .Include(p => p.PetType)
             .Include(p => p.AdoptionRequests)
             .ToListAsync();
        }

        public async Task<Pet> GetByIdPetAsync(int id)
        {
            var entity = await _context.Pets
               .Include(p => p.User)
               .Include(p => p.PetType)
               .FirstOrDefaultAsync(p => p.PetId == id && p.DeletedDate == null);

            if (entity == null)
                throw new Exception(Messages<Pet>.EntityNotFound);
            return entity;
        }

    }
}
