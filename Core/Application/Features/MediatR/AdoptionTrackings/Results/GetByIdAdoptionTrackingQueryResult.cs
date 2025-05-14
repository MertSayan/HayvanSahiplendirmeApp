namespace Application.Features.MediatR.AdoptionTrackings.Results
{
    public class GetByIdAdoptionTrackingQueryResult
    {
        public int AdoptionTrackingId { get; set; }
        public int AdoptionRequestId { get; set; }
        public int WeekNumber { get; set; }
        public string PhotoImageUrl { get; set; }
        public string? Note { get; set; }
        public string OwnerName { get; set; }
        public string SenderName { get; set; }
        public string PetName { get; set; }
    }
}
