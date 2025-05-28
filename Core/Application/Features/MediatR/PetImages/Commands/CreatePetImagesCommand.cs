using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.MediatR.PetImages.Commands
{
    public class CreatePetImagesCommand:IRequest<Unit>
    {
        public int PetId { get; set; }
        public List<IFormFile> PetImages { get; set; }

    }
}
