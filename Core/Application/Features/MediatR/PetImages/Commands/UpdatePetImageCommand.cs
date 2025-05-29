using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.MediatR.PetImages.Commands
{
    public class UpdatePetImageCommand:IRequest<Unit>
    {
        public int PetImageId { get; set; }
        public IFormFile PetImage { get; set; }
    }
}
