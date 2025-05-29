using Application.Constants;
using Application.Features.MediatR.Pets.Queries;
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

        public async Task<Pet> GetByIdPetAsync(int petId)
        {
            var entity = await _context.Pets
               .Include(p => p.User)
               .Include(p => p.PetType)
               .Include(p=>p.PetLikes)
               .FirstOrDefaultAsync(p => p.PetId == petId && p.DeletedDate == null);

           

            if (entity == null)
                throw new Exception(Messages<Pet>.EntityNotFound);
            return entity;
        }

        public async Task<List<Pet>> GetFilteredPetsAsync(GetAllFilterPetQuery query)
        {
            var pets =  _context.Pets
                .Include(p => p.PetType)
                .Include(p=>p.PetLikes)
                .Where(p => !p.IsAdopted && p.DeletedDate == null); // sadece aktif ilanlar

            if (query.PetTypeId.HasValue)
                pets = pets.Where(p => p.PetTypeId == query.PetTypeId);

            if (!string.IsNullOrWhiteSpace(query.Age))
                pets = pets.Where(p => p.Age == query.Age);

            if (!string.IsNullOrWhiteSpace(query.City))
                pets = pets.Where(p => p.City.ToLower() == query.City.ToLower());

            if (!string.IsNullOrWhiteSpace(query.Gender))
                pets = pets.Where(p => p.Gender == query.Gender);

            if (query.IsVaccinated.HasValue)
                pets = pets.Where(p => p.IsVaccinated == query.IsVaccinated);

            if (query.IsNeutered.HasValue)
                pets = pets.Where(p => p.IsNeutered == query.IsNeutered);

            // 🔽 Pagination uyguluyoruz
            int skip = (query.Page - 1) * query.PageSize;

            return await pets
             .OrderByDescending(p => p.PetLikes.Count(l => l.DeletedDate == null))
             .Skip(skip)
             .Take(query.PageSize)
             .ToListAsync();
        }

        public async Task<List<Pet>> GetTopLikedPetsAsync(int count)
        {
            return await _context.Pets
            .Include(p => p.PetLikes)
            .Include(p=>p.PetType)
            .Where(p => !p.IsAdopted && p.DeletedDate==null)
            .OrderByDescending(p => p.PetLikes.Count)
            .Take(count)
            .ToListAsync();
        }
    }
}
