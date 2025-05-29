namespace HayvanDto.PetDtos
{
    public class GetFeaturedPetsDto
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string MainImageUrl { get; set; }
        public int LikeCount { get; set; }
        public string Description { get; set; }
        public string PetTypeName { get; set; }
        public string Age { get; set; }
    }
}
