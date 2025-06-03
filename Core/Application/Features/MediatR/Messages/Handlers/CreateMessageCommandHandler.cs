using Application.Features.MediatR.Messages.Commands;
using Application.Interfaces.MessageInterface;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR.Messages.Handlers
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand,Unit>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public CreateMessageCommandHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = new Message
            {
                SenderId = request.SenderId,
                ReceiverId = request.ReceiverId,
                MessageText = request.MessageText,
                IsRead = false,
                CreatedDate = DateTime.Now
            };

            await _messageRepository.AddMessageAsync(message);
            await _messageRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
