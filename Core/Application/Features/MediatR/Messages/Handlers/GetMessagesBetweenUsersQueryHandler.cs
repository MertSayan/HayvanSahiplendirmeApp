using Application.Features.MediatR.Messages.Queries;
using Application.Interfaces.MessageInterface;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Messages.Handlers
{
    public class GetMessagesBetweenUsersQueryHandler:IRequestHandler<GetMessagesBetweenUsersQuery,List<MessageDto>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetMessagesBetweenUsersQueryHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<List<MessageDto>> Handle(GetMessagesBetweenUsersQuery request, CancellationToken cancellationToken)
        {
            var messages = await _messageRepository.GetConversationAsync(request.UserId1, request.UserId2);
            return messages.Select(m => new MessageDto
            {
                SenderId = m.SenderId,
                MessageText = m.MessageText,
                CreatedDate = m.CreatedDate ?? DateTime.MinValue
            }).ToList();
        }
    }
}
