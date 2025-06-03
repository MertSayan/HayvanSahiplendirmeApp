namespace HayvanDto.AdoptionRequestDtos
{
    public class GetAllAdoptionRequestBySenderIdDto
    {
        public int AdoptionRequestId { get; set; }
        public string PetName { get; set; }
        public string OwnerName { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PetImageUrl { get; set; }
        public int PetId { get; set; }

    }
}
