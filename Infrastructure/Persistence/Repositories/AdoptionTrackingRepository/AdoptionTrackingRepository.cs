using Application.Constants;
using Application.Interfaces.AdoptionTrackingInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.AdoptionTrackingRepository
{
    public class AdoptionTrackingRepository : IAdoptionTrackingRepository
    {
        private readonly HayvanContext _context;

        public AdoptionTrackingRepository(HayvanContext context)
        {
            _context = context;
        }

        public async Task<List<AdoptionTracking>> GetAllAdoptionTrackingAsync()
        {
            return await _context.AdoptionTrackings.Where(x=>x.DeletedDate==null)
                .Include(x => x.AdoptionRequest)
                    .ThenInclude(r => r.Owner)
                .Include(x => x.AdoptionRequest)
                    .ThenInclude(r => r.Sender)
                .Include(x => x.AdoptionRequest)
                    .ThenInclude(r => r.Pet)
                .ToListAsync();
        }

        public async Task<AdoptionTracking> GetByIdAdoptionTrackingAsync(int id)
        {
            var entity=await _context.AdoptionTrackings
                .Include(x => x.AdoptionRequest)
                    .ThenInclude(r => r.Owner)
                .Include(x => x.AdoptionRequest)
                    .ThenInclude(r => r.Sender)
                .Include(x => x.AdoptionRequest)
                    .ThenInclude(r => r.Pet)
                .FirstOrDefaultAsync(x=>x.AdoptionTrackingId==id && x.DeletedDate==null);
            if(entity==null)
                throw new Exception(Messages<AdoptionTracking>.EntityNotFound);
            return entity;
        }
    }
}
