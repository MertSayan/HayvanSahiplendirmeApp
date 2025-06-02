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

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
