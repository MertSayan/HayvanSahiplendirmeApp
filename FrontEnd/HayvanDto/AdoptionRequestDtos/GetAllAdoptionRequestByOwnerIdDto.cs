namespace HayvanDto.AdoptionRequestDtos
{
    public class GetAllAdoptionRequestByOwnerIdDto
    {
        public int AdoptionRequestId { get; set; }
        public string PetName { get; set; }
        public string SenderName { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SenderImageUrl { get; set; }
        public int SenderId { get; set; }
    }
}
