namespace Domain
{
    public class AdoptionTracking : Entity
    {
        public int AdoptionTrackingId { get; set; }
        public int AdoptionRequestId { get; set; }
        public AdoptionRequest AdoptionRequest { get; set; }
        public int WeekNumber { get; set; }
        public string PhotoImageUrl { get; set; }
        public string Note { get; set; }
    }
}
