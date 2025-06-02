using Application.Features.MediatR.Messages.Results;
using Application.Interfaces.MessageInterface;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.MessageRepository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly HayvanContext _context;

        public MessageRepository(HayvanContext context)
        {
            _context = context;
        }

        public async Task AddMessageAsync(Message message)
        {
            message.CreatedDate = DateTime.Now;
            await _context.Messages.AddAsync(message);
        }

        public async Task<List<Message>> GetConversationAsync(int userId1, int userId2)
        {
            return await _context.Messages
                .Where(m =>
                    (m.SenderId == userId1 && m.ReceiverId == userId2) ||
                    (m.SenderId == userId2 && m.ReceiverId == userId1))
                .OrderBy(m => m.CreatedDate)
                .ToListAsync();
        }

        public async Task<List<GetUserConversationDto>> GetConversationsForUserAsync(int userId)
        {
            var messages = await _context.Messages
               .Where(m => m.SenderId == userId || m.ReceiverId == userId)
               .GroupBy(m => m.SenderId == userId ? m.ReceiverId : m.SenderId)
               .Select(g => new {
                   UserId = g.Key,
                   LastMessage = g.OrderByDescending(m => m.CreatedDate).FirstOrDefault(),
                   UnreadCount = g.Count(m =>
                       m.ReceiverId == userId &&
                       !m.IsRead)
               })
               .ToListAsync();

            var userIds = messages.Select(x => x.UserId).ToList();

            var users = await _context.Users
                .Where(u => userIds.Contains(u.UserId))
                .ToDictionaryAsync(u => u.UserId);

            return messages.Select(x => new GetUserConversationDto
            {
                ReceiverId = x.UserId,
                ReceiverName = users[x.UserId].Name,
                ReceiverPhotoUrl = users[x.UserId].ProfilePictureUrl ?? "/images/default-user.png",
                LastMessage = x.LastMessage.MessageText,
                LastMessageTime = x.LastMessage?.CreatedDate ?? DateTime.MinValue,
                UnreadCount = x.UnreadCount
            }).ToList();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
