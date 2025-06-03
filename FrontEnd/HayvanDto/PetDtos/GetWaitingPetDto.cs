namespace HayvanDto.PetDtos
{
    public class GetWaitingPetDto
    {
        public int PetId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string PetTypeName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
