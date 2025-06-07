using Application.Enums;
using Application.Factories;
using Application.Features.MediatR.Users.Commands;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Factories
{
    public class UserFactory : IUserFactory
    {
        private readonly IMapper _mapper;

        public UserFactory(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<User> CreateUserAsync(CreateUserCommand request)
        {
            var user = _mapper.Map<User>(request); // AutoMapper kullanımı

            if (request.ProfilePictureUrl != null && request.ProfilePictureUrl.Length > 0)
            {
                var uploadsFolderPath = Path.Combine("C:\\Users\\baris\\source\\repos\\HayvanSahiplendirmeApp\\FrontEnd\\HayvanWebUI", "wwwroot", "users");

                if (!Directory.Exists(uploadsFolderPath))
                    Directory.CreateDirectory(uploadsFolderPath);

                var fileExtension = Path.GetExtension(request.ProfilePictureUrl.FileName);
                var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                var filePath = Path.Combine(uploadsFolderPath, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.ProfilePictureUrl.CopyToAsync(fileStream);
                }

                user.ProfilePictureUrl = $"/users/{uniqueFileName}";
            }

            user.RoleId = (int)UserRole.Kullanici;

            return user;
        }
    }
}
