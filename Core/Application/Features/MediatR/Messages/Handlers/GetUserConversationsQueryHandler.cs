using Application.Features.MediatR.Messages.Queries;
using Application.Features.MediatR.Messages.Results;
using Application.Interfaces.MessageInterface;
using MediatR;

namespace Application.Features.MediatR.Messages.Handlers
{
    public class GetUserConversationsQueryHandler : IRequestHandler<GetUserConversationsQuery, List<GetUserConversationDto>>
    {
        private readonly IMessageRepository _messageRepository;

        public GetUserConversationsQueryHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public async Task<List<GetUserConversationDto>> Handle(GetUserConversationsQuery request, CancellationToken cancellationToken)
        {
            return await _messageRepository.GetConversationsForUserAsync(request.UserId);
        }
    }
}
