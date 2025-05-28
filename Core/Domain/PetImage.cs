namespace Domain
{
    public class PetImage:Entity
    {
        public int PetImageId { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public string PetImageUrl { get; set; }
    }
}
