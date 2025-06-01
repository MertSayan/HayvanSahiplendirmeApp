namespace HayvanDto.PetDtos
{
    public class GetLastPetsDto
    {
        public int PetId { get; set; }
        public string UserNameSurname { get; set; }
        public string Name { get; set; }
        public string PetTypeName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
