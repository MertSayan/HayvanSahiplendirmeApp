﻿using Application.Enums;
using Application.Interfaces.UserInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly HayvanContext _context;

        public UserRepository(HayvanContext context)
        {
            _context = context;
        }

        //Adminini tüm kullanıcıları görmesi için oluşturuldu.Password alanı yok
        public async Task<List<User>> GetAllUserAsync()
        {
            return await _context.Users.Where(x => x.DeletedDate == null)
                .Include(x => x.Role)
                .ToListAsync();
        }

        //Kullanıcı kendi bilgilerini görebilmesi için oluşturuldu. O yüzden Dto kısmında password alanı da var
        public async Task<User> GetByIdUserAsync(int id)
        {
            var entity = await _context.Users
               .Include(p => p.Role)
               .FirstOrDefaultAsync(p => p.UserId == id && p.DeletedDate == null);

            if (entity == null)
                throw new Exception("User bulunamadı.");
            return entity;
        }

        public async Task<User> GetByIdUserDetailsForAdminAsync(int id)
        {
            var entity = await _context.Users
               .Include(p => p.Role)
               .FirstOrDefaultAsync(p => p.UserId == id && p.DeletedDate == null);

            if (entity == null)
                throw new Exception("User bulunamadı.");
            return entity;
        }

        public async Task<(int totalPets, int totalLikes, int successfulAdoptions)> GetUserStatsAsync(int userId)
        {
            var totalPets = await _context.Pets
        .CountAsync(p => p.UserId == userId && p.DeletedDate == null);

            var totalLikes = await _context.Pets
                .Where(p => p.UserId == userId && p.DeletedDate == null)
                .SelectMany(p => p.PetLikes)
                .CountAsync(p => p.DeletedDate == null);

            var successfulAdoptions = await _context.AdoptionRequests
                .CountAsync(r => r.OwnerId == userId && r.Status == AdoptionStatus.Accepted.ToString() && r.DeletedDate == null);

            return (totalPets, totalLikes, successfulAdoptions);
        }
    }
}
