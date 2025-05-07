using MediatR;

namespace Application.Features.MediatR.PetLikes.Commands
{
    public class DeletePetLikeCommand:IRequest<Unit>
    {
        public int Id { get; set; }

        public DeletePetLikeCommand(int id)
        {
            Id = id;
        }
    }
}
