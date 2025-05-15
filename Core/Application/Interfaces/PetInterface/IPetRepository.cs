using Application.Features.MediatR.Pets.Results;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.PetInterface
{
    public interface IPetRepository
    {
        Task<List<Pet>> GetAllPetAsync(); //user,pettype ile birlikte
        Task<Pet> GetByIdPetAsync(int id); //user,pettype ile birlikte
        Task<List<Pet>> GetAllPetByOwnerIdAsync(int ownerId);
    }
}
