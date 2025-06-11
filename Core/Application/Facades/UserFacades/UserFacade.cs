using Application.Features.MediatR.Users.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Facades.UserFacades
{
    public class UserFacade
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserFacade(IMapper mapper, IRepository<User> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task UpdateUserAsync(UpdateUserCommand request)
        {
            var user = await _repository.GetByIdAsync(request.UserId);

            var profilePicturUrl = user.ProfilePictureUrl;

            if (request.ProfilePictureUrl != null && request.ProfilePictureUrl.Length > 0)
            {
                if (!string.IsNullOrEmpty(user.ProfilePictureUrl))
                {
                    var oldImagePath = Path.Combine("C:\\Users\\baris\\Source\\Repos\\HayvanSahiplendirmeApp\\FrontEnd\\HayvanWebUI", "wwwroot", user.ProfilePictureUrl.TrimStart('/'));
                    if (File.Exists(oldImagePath))
                    {
                        File.Delete(oldImagePath);
                    }
                }

                // Yeni resmi kaydet
                var uploadsFolderPath = Path.Combine("C:\\Users\\baris\\Source\\Repos\\HayvanSahiplendirmeApp\\FrontEnd\\HayvanWebUI", "wwwroot", "users");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                var extension = Path.GetExtension(request.ProfilePictureUrl.FileName);
                var uniqueName = $"{Guid.NewGuid()}{extension}";
                var filePath = Path.Combine(uploadsFolderPath, uniqueName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.ProfilePictureUrl.CopyToAsync(stream);

                    profilePicturUrl = $"/users/{uniqueName}";
                }
            }

            _mapper.Map(request, user);
            user.ProfilePictureUrl = profilePicturUrl;
            await _repository.UpdateAsync(user);


        }
    }
}
