using MediatR;

namespace Application.Features.MediatR.Messages.Commands
{
    public class CreateMessageCommand:IRequest<Unit>
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string MessageText { get; set; }
    }
}
