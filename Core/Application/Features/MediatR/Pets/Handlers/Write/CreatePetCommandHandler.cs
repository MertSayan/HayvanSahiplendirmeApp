using Application.Features.MediatR.Pets.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.MediatR.Pets.Handlers.Write
{
    public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand,Unit>
    {
        private readonly IRepository<Pet> _repository;
        private readonly IMapper _mapper;
        public CreatePetCommandHandler(IRepository<Pet> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            string photoPath = null;
            if(request.MainImageUrl!=null && request.MainImageUrl.Length>0)
            {
                var uploadsFolderPath=Path.Combine("C:\\Users\\furka\\Source\\Repos\\HayvanSahiplendirmeApp\\FrontEnd\\HayvanWebUI", "wwwroot", "PetMain");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }
                var fileExtension = Path.GetExtension(request.MainImageUrl.FileName);
                var uniqueFileName = $"{Guid.NewGuid()}_{fileExtension}";
                var filePath=Path.Combine(uploadsFolderPath, uniqueFileName);

                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.MainImageUrl.CopyToAsync(fileStream);
                }

                photoPath= $"/PetMain/{uniqueFileName}";
            }


            var pet = _mapper.Map<Pet>(request);
            pet.MainImageUrl = photoPath;
            pet.ApprovalStatus = "Pending";
            await _repository.CreateAsync(pet);
            return Unit.Value;
        }
    }
}
