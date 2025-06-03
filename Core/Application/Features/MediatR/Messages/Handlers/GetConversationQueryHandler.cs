using Application.Features.MediatR.Messages.Queries;
using Application.Interfaces.MessageInterface;
using Domain;
using MediatR;

namespace Application.Features.MediatR.Messages.Handlers
{
    public class GetConversationQueryHandler : IRequestHandler<GetConversationQuery, List<Message>>
    {
        private readonly IMessageRepository _messageRepository;

        public GetConversationQueryHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<List<Message>> Handle(GetConversationQuery request, CancellationToken cancellationToken)
        {
            return await _messageRepository.GetConversationAsync(request.UserId1, request.UserId2);
        }
    }
}
