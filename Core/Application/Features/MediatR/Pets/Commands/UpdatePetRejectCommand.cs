using MediatR;

namespace Application.Features.MediatR.Pets.Commands
{
    public class UpdatePetRejectCommand:IRequest<Unit>
    {
        public int Id { get; set; }

    }
}
