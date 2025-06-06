﻿using Application.Features.MediatR.Pets.Queries;
using Domain;

namespace Application.Interfaces.PetInterface
{
    public interface IPetRepository
    {
        Task<List<Pet>> GetAllPetAsync(); //user,pettype ile birlikte
        Task<Pet> GetByIdPetAsync(int id); //user,pettype ile birlikte
        Task<List<Pet>> GetAllPetByOwnerIdAsync(int ownerId);
        Task<List<Pet>> GetAllActivePetByOwnerIdAsync(int ownerId);
        Task<List<Pet>> GetAllAdoptedPetByOwnerIdAsync(int ownerId);
        Task<List<Pet>> GetFilteredPetsAsync(GetAllFilterPetQuery query);
        Task<List<Pet>> GetTopLikedPetsAsync(int count);
        Task<List<Pet>> GetLastPetsAsync(int count);


    }
}
