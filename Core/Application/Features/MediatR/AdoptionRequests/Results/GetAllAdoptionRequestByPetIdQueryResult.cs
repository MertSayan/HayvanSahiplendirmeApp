using Domain;

namespace Application.Features.MediatR.AdoptionRequests.Results
{
    public class GetAllAdoptionRequestByPetIdQueryResult
    {
        public int AdoptionRequestId { get; set; }
        public int PetId { get; set; }
        public string PetName { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string Status { get; set; } 
        public string? Note { get; set; } 
    }
}
