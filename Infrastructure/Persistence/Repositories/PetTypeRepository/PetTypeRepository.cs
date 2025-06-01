using Application.Features.MediatR.PetTypes.Results;
using Application.Interfaces.PetTypeInterface;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.PetTypeRepository
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private readonly HayvanContext _context;

        public PetTypeRepository(HayvanContext context)
        {
            _context = context;
        }

        public async Task<List<GetPetTypeDistributionQueryResult>> GetPetTypeDistributionAsync()
        {
            var result = await _context.Pets
               .Where(p => p.DeletedDate == null)
               .GroupBy(p => p.PetTypeId)
               .Select(g => new GetPetTypeDistributionQueryResult
               {
                   PetTypeName = _context.PetTypes
                       .Where(pt => pt.PetTypeId == g.Key)
                       .Select(pt => pt.PetTypeName)
                       .FirstOrDefault(),
                   Count = g.Count()
               })
               .ToListAsync();

            return result;
        }
    }
}
