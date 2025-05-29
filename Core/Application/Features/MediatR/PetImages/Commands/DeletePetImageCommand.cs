using MediatR;

namespace Application.Features.MediatR.PetImages.Commands
{
    public class DeletePetImageCommand:IRequest<Unit>
    {
        public int Id { get; set; }

        public DeletePetImageCommand(int id)
        {
            Id = id;
        }
    }
}
    