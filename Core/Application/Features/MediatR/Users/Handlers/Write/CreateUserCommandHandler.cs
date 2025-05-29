using Application.Enums;
using Application.Features.MediatR.Users.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.Users.Handlers.Write
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IMapper mapper, IRepository<User> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            string photoPath = null;
            if(request.ProfilePictureUrl != null && request.ProfilePictureUrl.Length>0)
            {
                var uploadsFolderPath = Path.Combine("C:\\csharpprojeler\\HayvanSahiplendirmeApp\\FrontEnd\\HayvanWebUI", "wwwroot", "users");
                if(!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                var fileExtension = Path.GetExtension(request.ProfilePictureUrl.FileName);
                var uniqueFileName = $"{Guid.NewGuid()}_{fileExtension}";
                var filePath = Path.Combine(uploadsFolderPath,uniqueFileName);

                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.ProfilePictureUrl.CopyToAsync(fileStream);
                }

                photoPath = $"/users/{uniqueFileName}";

            }

            var user = _mapper.Map<User>(request);
            user.RoleId = (int)UserRole.Kullanici;
            user.ProfilePictureUrl= photoPath;
            await _repository.CreateAsync(user);
            return Unit.Value;
        }
    }
}
