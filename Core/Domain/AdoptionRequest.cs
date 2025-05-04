namespace Domain
{
    public class AdoptionRequest:Entity
    {
        public int AdoptionRequestId { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public string Status { get; set; }

        public  ICollection<AdoptionTracking> Trackings { get; set; } = new List<AdoptionTracking>();
    }
}
