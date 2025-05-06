using Application.Constants;
using Application.Interfaces.PetCommentInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.PetCommentRepository
{
    public class PetCommentRepository : IPetCommentRepository
    {
        private readonly HayvanContext _context;

        public PetCommentRepository(HayvanContext context)
        {
            _context = context;
        }

        public async Task<List<PetComment>> GetAllPetCommentByPetIdAsync(int id)
        {
            var result = await _context.PetComments.Where(x => x.DeletedDate == null && x.PetId==id)
                       .Include(x => x.User)
                       .Include(x => x.Pet)
                       .ToListAsync();

            if(result.Count == 0)
            {
                throw new Exception(Messages<PetComment>.EntityCantGet);
            }
            
            return result;
        }
    }
}
