using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.PetCommentInterface
{
    public interface IPetCommentRepository
    {
        Task<List<PetComment>> GetAllPetCommentByPetIdAsync(int id);

    }
}
