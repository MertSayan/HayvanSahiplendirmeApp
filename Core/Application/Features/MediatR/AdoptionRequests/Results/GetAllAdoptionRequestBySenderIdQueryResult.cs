namespace Application.Features.MediatR.AdoptionRequests.Results
{
    public class GetAllAdoptionRequestBySenderIdQueryResult
    {
        public int AdoptionRequestId { get; set; }
        public string PetName { get; set; }
        public string OwnerName { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
