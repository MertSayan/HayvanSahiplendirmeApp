using MediatR;

namespace Application.Features.MediatR.Pets.Commands
{
    public class UpdatePetAcceptCommand:IRequest<Unit>
    {
        public int Id { get; set; }

    }
}
