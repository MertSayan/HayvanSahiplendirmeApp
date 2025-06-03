using Application.Features.MediatR.Messages.Commands;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace WebApi.SignalR.Hubs
{
    public class MessageHub : Hub
    {
        private static ConcurrentDictionary<int, string> _userConnections = new();

        private readonly IMediator _mediator;

        public MessageHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var item = _userConnections.FirstOrDefault(x => x.Value == Context.ConnectionId);
            if (!item.Equals(default(KeyValuePair<int, string>)))
            {
                _userConnections.TryRemove(item.Key, out _);
            }

            return base.OnDisconnectedAsync(exception);
        }

        public Task RegisterUser(int userId)
        {
            _userConnections[userId] = Context.ConnectionId;
            Console.WriteLine($"✅ {userId} bağlantısı kaydedildi: {Context.ConnectionId}");
            return Task.CompletedTask;
        }

        public async Task SendMessage(int senderId, int receiverId, string message)
        {
            // 1. Veritabanına mesajı kaydet
            var command = new CreateMessageCommand
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                MessageText = message
            };

            await _mediator.Send(command);

            // 2. SignalR ile mesajı her iki tarafa gönder
            if (_userConnections.TryGetValue(receiverId, out var receiverConnectionId))
            {
                await Clients.Client(receiverConnectionId).SendAsync("ReceiveMessage", senderId, receiverId, message);
            }

            if (_userConnections.TryGetValue(senderId, out var senderConnectionId))
            {
                await Clients.Client(senderConnectionId).SendAsync("ReceiveMessage", senderId, receiverId, message);
            }

            // 3. 🔁 Sol konuşma panelini güncellemek için her iki kullanıcıya event gönder
            if (_userConnections.TryGetValue(receiverId, out var convReceiverConn))
            {
                await Clients.Client(convReceiverConn).SendAsync("RefreshConversationList");
            }

            if (_userConnections.TryGetValue(senderId, out var convSenderConn))
            {
                await Clients.Client(convSenderConn).SendAsync("RefreshConversationList");
            }
        }


        public async Task NotifyConversationUpdate(int userId)
        {
            if (_userConnections.TryGetValue(userId, out var connectionId))
            {
                await Clients.Client(connectionId).SendAsync("RefreshConversationList");
            }
        }
    }
}
