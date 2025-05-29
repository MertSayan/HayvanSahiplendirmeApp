namespace HayvanDto.AdoptionRequestDtos
{
    public class CreateAdoptionRequestDto
    {
        public int PetId { get; set; }
        public int SenderId { get; set; }
        public int OwnerId { get; set; }
        public string? Note { get; set; } //istek yollarken kısa bir not yazabilecek
    }
}
