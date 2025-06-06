﻿using Application.Features.MediatR.Messages.Results;
using Domain;
using MediatR;

namespace Application.Interfaces.MessageInterface
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetConversationAsync(int userId1, int userId2);
        Task AddMessageAsync(Message message);
        Task SaveChangesAsync();
        Task<List<GetUserConversationDto>> GetConversationsForUserAsync(int userId);
    }
}
