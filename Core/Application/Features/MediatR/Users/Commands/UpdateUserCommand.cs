﻿using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.MediatR.Users.Commands
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public int UserId { get; set; }  
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IFormFile? ProfilePictureUrl { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string? AboutMe { get; set; } // Profil açıklaması
    }
}
