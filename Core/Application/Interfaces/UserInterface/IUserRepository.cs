﻿using Application.Features.MediatR.Users.Results;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.UserInterface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUserAsync(); 
        Task<User> GetByIdUserAsync(int id); 
        Task<User> GetByIdUserDetailsForAdminAsync(int id);
        Task<(int totalPets, int totalLikes, int successfulAdoptions)> GetUserStatsAsync(int userId);
        Task<AdminDashboardStatsQueryResult> GetDashboardStatsAsync(); //Bunu statsrepository diye bir şeye alabilirdim üşendim. :)


    }
}
