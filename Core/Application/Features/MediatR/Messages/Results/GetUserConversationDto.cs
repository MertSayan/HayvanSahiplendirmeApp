namespace Application.Features.MediatR.Messages.Results
{
    public class GetUserConversationDto
    {
        public int ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhotoUrl { get; set; }
        public string LastMessage { get; set; }
        public DateTime LastMessageTime { get; set; }
        public int UnreadCount { get; set; }
    }
}
