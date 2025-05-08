using Application.Constants;
using Application.Interfaces.AdoptionRequestInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.AdoptionRequestRepository
{
    public class AdoptionRequestRepository : IAdoptionRequestRepository
    {
        private readonly HayvanContext _context;

        public AdoptionRequestRepository(HayvanContext context)
        {
            _context = context;
        }

        public async Task<List<AdoptionRequest>> GetAllAdoptionRequestAsync()
        {
            return await _context.AdoptionRequests.Where(x=>x.DeletedDate==null)
                .Include(x=>x.Pet)
                .Include(x=>x.Sender)
                .Include(x=>x.Owner)
                .ToListAsync();
        }

        public async Task<List<AdoptionRequest>> GetAllAdoptionRequestByPetIdAsync(int id)
        {
            return await _context.AdoptionRequests.Where(x => x.DeletedDate == null && x.PetId == id)
                .Include(x => x.Sender)
                .Include(x => x.Owner)
                .Include(x=>x.Pet)
                .ToListAsync();
        }

        public async Task<List<AdoptionRequest>> GetAllAdoptionRequestByUserIdAsync(int id)
        {
            return await _context.AdoptionRequests.Where(x => x.DeletedDate == null && x.OwnerId == id)
                .Include(x => x.Sender)
                .Include(x => x.Owner)
                .Include(x => x.Pet)
                .ToListAsync();
        }

        public async Task<AdoptionRequest> GetByIdAdoptionRequest(int id)
        {
            var entity = await _context.AdoptionRequests
                .Include(x => x.Sender)
                .Include(x => x.Owner)
                .Include(x => x.Pet)
                .FirstOrDefaultAsync(x => x.AdoptionRequestId == id && x.DeletedDate == null);
            if (entity == null)
                throw new Exception(Messages<AdoptionRequest>.EntityNotFound);
            return entity;
        }
    }
}
