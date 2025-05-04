namespace Domain
{
    public class Message : Entity
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }
        public int ReceiverId { get; set; }
        public User Receiver { get; set; }
        public string MessageText { get; set; }
        public bool IsRead { get; set; }
    }
}
