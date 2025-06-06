﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.AdoptionRequestInterface
{
    public interface IAdoptionRequestRepository
    {
        Task<List<AdoptionRequest>> GetAllAdoptionRequestAsync();
        Task<List<AdoptionRequest>> GetAllAdoptionRequestByPetIdAsync(int id);
        Task<List<AdoptionRequest>> GetAllIncomingAdoptionRequestByOwnerIdAsync(int id);
        Task<AdoptionRequest> GetByIdAdoptionRequest(int id);
        Task<List<AdoptionRequest>> GetAllAdoptionRequestBySenderId(int id);
        Task CreateAdoptionRequestAsync(AdoptionRequest entity);
        Task<bool> HasUserRequestedAdoptionAsync(int userId, int petId);

    }
}
